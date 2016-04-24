
package retry_release_thread;

import static dzd.server.DZDServer.boards;
import static dzd.server.DZDServer.conn;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * PulseSignal - класс, имитирующий работу дискретного(прерывистого) сигнала
 * 
 * @package dzd.server
 * @author Gleb An
 */

public class PulseSignal extends Thread{
    
        /**
         * Время при котором сигнал на светофоре горит/не горит
         * 
         * @var int
         */
        private int sleepTime = 3000;

        /**
         * Тип сигнализации светофора:
         *      0 - сигнал не задан, выход из потока
         *      1 - мигание только первого сигнала (желтого)
         *      2 - мигание только второго сигнала (зеленого)
         * 
         * @var int
         */
        private int typeSignal = 1;

        /**
         * id объекта светофора в базе данных
         * 
         * @var int
         */
        private int object;
        
        /**
         * PulseSignal - конструктор, инициализирующий значения полей класса
         * 
         * @param type - сигнал, который будет иметь дискретное отображение
         * @param sleepTime - время при котором сигнал горит / не горит в миллисек.
         * @param object - id светофора в базе данных
         */
        PulseSignal(int object, String type, int sleepTime)
        {
            if (type == "Yellow") this.typeSignal = 1;
            else if (type == "Green") this.typeSignal = 2;
            else this.typeSignal = 0;
            this.sleepTime = sleepTime;
            this.object = object;
        }
        
        /**
         * PulseSignal - конструктор, инициализирующий значения полей класса
         *              по умолчанию: время "засыпания" - 3000 мс,
         *                            тип сигнализации - мигание только верхнего
         *                                                      желтого сигнала
         * 
         * @param object - id светофора в базе данных
         */
        PulseSignal(int object)
        {
            this.sleepTime = 3000;
            this.typeSignal = 1;
        }
        
        /**
         * run - запуск нити при вызове метода start() из внешней среды
         * 
         * @param void
         * @return void
         */
        @Override
        public void run()
        {
            if (this.typeSignal == 0)
            {
                interrupt();
            }
            else
            {             
                try 
                {
                    if (this.typeSignal == 1)
                    {
                        discreteYellowSignal();
                    }
                    else 
                        if (this.typeSignal == 2)
                        {
                            discreteGreenSignal();
                        }
                }
                catch (Exception e) 
                {
                    // System.err.println("Can't get commands (" + e + ")");
                }
            }
        }
        
        /**
         * discreteYellowSignal - реализует мигание только 
         *                      желтого сигнала светофора (1 сигнал)
         * 
         * @param void
         * @return void
         * @throws SQLException, InterruptedException
         */
        private void discreteYellowSignal() throws SQLException, InterruptedException
        {
            ResultSet rs = resultQueryInDB();
            String oPort1 = rs.getString(2); // DPPB
            String oPort2 = rs.getString(3);
            String oPort3 = rs.getString(4);
            String oPort4 = rs.getString(5);
            //Выключаем все сигналы на светофоре
            boards.setState(oPort1, 0); // ж   ман. син
            boards.setState(oPort2, 0); // з   ман. бел
            boards.setState(oPort3, 0); // к
            boards.setState(oPort4, 0); // ж (нижний)
            while ( !this.isInterrupted() )
            {
                boards.setState(oPort1, 1);
                boards.setState(oPort2, 0);
                boards.setState(oPort3, 0);
                boards.setState(oPort4, 0);
                sleep(this.sleepTime);
                boards.setState(oPort1, 0);
                boards.setState(oPort2, 0);
                boards.setState(oPort3, 0);
                boards.setState(oPort4, 0);
                sleep(this.sleepTime);
            }
        }
        
        /**
         * discreteGreenSignal - реализует мигание только 
         *                  зеленого сигнала светофора (2 сигнал)
         * 
         * @param void
         * @return void
         * @throws SQLException, InterruptedException
         */
        private void discreteGreenSignal() throws SQLException, InterruptedException
        {
            ResultSet rs = resultQueryInDB();
            String oPort1 = rs.getString(2); // DPPB
            String oPort2 = rs.getString(3);
            String oPort3 = rs.getString(4);
            String oPort4 = rs.getString(5);
            //Выключаем все сигналы на светофоре
            boards.setState(oPort1, 0); // ж   ман. син
            boards.setState(oPort2, 0); // з   ман. бел
            boards.setState(oPort3, 0); // к
            boards.setState(oPort4, 0); // ж (нижний)
            while ( !this.isInterrupted() )
            {
                boards.setState(oPort1, 0);
                boards.setState(oPort2, 1);
                boards.setState(oPort3, 0);
                boards.setState(oPort4, 0);
                sleep(this.sleepTime);
                boards.setState(oPort1, 0);
                boards.setState(oPort2, 0);
                boards.setState(oPort3, 0);
                boards.setState(oPort4, 0);
                sleep(this.sleepTime);
            }
        }
        
        /**
         * resultQueryInDB - возвращает результат запроса
         *              из таблицы objects, по заданному object
         * 
         * @return void
         * @throws SQLException 
         */
        public ResultSet resultQueryInDB() throws SQLException
        {
            Statement stmt = conn.createStatement();
            String query = "SELECT name,port1,port2,port3,port4 FROM objects WHERE id=" + this.object;
            ResultSet rs = stmt.executeQuery(query);
            rs.next();
            DZDServer.Log("Signal name is " + rs.getString(1), 10);
            return rs;
        }
}
