//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by Fernflower decompiler)
//

import com.mysql.jdbc.Connection;
import java.awt.Component;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.SimpleDateFormat;
import java.util.Date;
import javax.swing.BorderFactory;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextArea;
import javax.swing.JTextField;
import javax.swing.border.Border;
import javax.swing.border.TitledBorder;

public class Send_to_the_database extends JFrame {
    JButton b1, b2, b3;
    JTextArea l2;
    JTextField tf1;
    JTextField tf2;
    JTextField tf3;
    JTextField tf4;
    JTextField tf5;
    JTextField tf6;
    JTextField tf7;
    JLabel jl1;
    JLabel jl2;
    JLabel jl3;
    JLabel jl4;
    JLabel jl5;
    JLabel jl6;
    JLabel jl7;
    JPanel panel;
    JPanel panel2;
    int ColTest = 0;
    StringBuffer buffer;
    Send_to_the_database.handler hand = new Send_to_the_database.handler();

    private String getTime() {
        SimpleDateFormat dateFormat = new SimpleDateFormat("HH:mm:ss");
        Date date = new Date();
        return dateFormat.format(date);
    }

    private String getDate() {
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
        Date date = new Date();
        return dateFormat.format(date);
    }

    public Send_to_the_database(String s) {
        super(s);
        this.setLayout(new FlowLayout());
        this.tf1 = new JTextField("Номер теста", 20);
        this.tf2 = new JTextField("Статус", 20);
        this.tf3 = new JTextField("Дата", 20);
        this.tf4 = new JTextField("Время", 20);
        this.tf5 = new JTextField("База данных", 20);
        this.tf6 = new JTextField("Сервер приложений", 20);
        this.tf7 = new JTextField("Сотрудник", 20);
        this.jl1 = new JLabel("Идентификатор теста:");
        this.jl2 = new JLabel("Статус:");
        this.jl3 = new JLabel("Дата сохранения результата:");
        this.jl4 = new JLabel("Время сохранения результата:");
        this.jl5 = new JLabel("База данных:");
        this.jl6 = new JLabel("Сервер приложений:");
        this.jl7 = new JLabel("Сотрудник:");
        this.panel = new JPanel();
        this.panel2 = new JPanel();
        this.buffer = new StringBuffer(reader.a);
        this.ColTest = 0;
        char[] q = reader.a.toCharArray();
        int var3 = q.length;

        for(int database_version = 0; database_version < var3; ++database_version) {
            char application_server_version = q[database_version];
            if(application_server_version == 33) {
                ++this.ColTest;
            }
        }

        boolean var13 = false;
        String var14;
        if(reader.a.contains("завершился неудачно")) {
            var14 = reader.a.substring(reader.a.indexOf("завершился") - 4, reader.a.indexOf("неудачно") - 12);
            this.tf1.setText(var14);
            this.tf2.setText("не прошел");
            var13 = true;
        }

        if(reader.a.contains("пройден") && !var13) {
            var14 = reader.a.substring(reader.a.indexOf("пройден") - 4, reader.a.indexOf("пройден") - 1);
            this.tf1.setText(var14);
            this.tf2.setText("прошел");
        }

        var14 = "";
        String var15 = "";

        String date;
        try {
            DBProcessor ColTesti = new DBProcessor();
            Connection a = ColTesti.getConnection(avt.url, avt.username, avt.password);
            Statement time = a.createStatement();
            date = "select database_version, application_server_version from testing_process.versions_of_the_system_components WHERE id_version = (select max(id_version) from testing_process.versions_of_the_system_components);";

            for(ResultSet etched = time.executeQuery(date); etched.next(); var15 = etched.getString("application_server_version")) {
                var14 = etched.getString("database_version");
            }

            a.close();
        } catch (SQLException var12) {
            JOptionPane.showMessageDialog((Component)null, "Не удалось записать информацию в БД!");
        }

        this.l2 = new JTextArea("Осталось сохранить", 1, 4);
        this.add(this.l2);
        reader.a = this.buffer.toString();
        String var16 = "Осталось сохранить" + this.ColTest;
        String var17 = " тестов";
        if(var16.endsWith("1")) {
            var17 = " тест";
        }

        if(var16.endsWith("2") || var16.endsWith("3") || var16.endsWith("5")) {
            var17 = " теста";
        }

        var16 = var16 + var17;
        this.l2.setText(var16);
        String var18 = this.getTime();
        date = this.getDate();
        this.b1 = new JButton("Сохранить");
        this.b1.addActionListener(this.hand);
        this.b2 = new JButton("Пропустить");
        this.b2.addActionListener(this.hand);
        this.b3 = new JButton("Отмена");
        this.b3.addActionListener(this.hand);
        Border var19 = BorderFactory.createEtchedBorder();
        TitledBorder titled = BorderFactory.createTitledBorder(var19, "Версии компонентов АСУ СПС");
        this.panel.setBorder(titled);
        this.panel.setLayout(new GridLayout(4, 1));
        this.panel2.setLayout(new GridLayout(10, 1));
        this.add(this.panel2);
        this.add(this.panel);
        this.panel2.add(this.jl1);
        this.panel2.add(this.tf1);
        this.panel2.add(this.jl2);
        this.panel2.add(this.tf2);
        this.panel2.add(this.jl3);
        this.panel2.add(this.tf3);
        this.panel2.add(this.jl4);
        this.panel2.add(this.tf4);
        this.panel2.add(this.jl7);
        this.panel2.add(this.tf7);
        this.panel.add(this.jl5);
        this.panel.add(this.tf5);
        this.panel.add(this.jl6);
        this.panel.add(this.tf6);
        this.tf3.setText(date);
        this.tf4.setText(var18);
        this.tf5.setText(var14);
        this.tf6.setText(var15);
        this.tf7.setText(avt.pr);
        this.add(this.b1);
        this.add(this.b2);
        this.add(this.b3);
    }

    public class handler implements ActionListener {
        public handler() {
        }

        public void actionPerformed(ActionEvent e) {
            try {
                boolean ex;
                int mm;
                if(e.getSource() == Send_to_the_database.this.b1) {
                    ex = false;
                    if(reader.a.contains("завершился неудачно")) {
                        mm = Send_to_the_database.this.buffer.indexOf("завершился неудачно");
                        Send_to_the_database.this.buffer.replace(mm, mm + 21, "");
                        ex = true;
                    }

                    if(reader.a.contains("пройден") && !ex) {
                        mm = Send_to_the_database.this.buffer.indexOf("пройден");
                        Send_to_the_database.this.buffer.replace(mm, mm + 21, "");
                    }

                    reader.a = Send_to_the_database.this.buffer.toString();
                    String S = "";
                    String test_id = "";
                    String id_version = "";

                    try {
                        DBProcessor S1 = new DBProcessor();
                        Connection conn = S1.getConnection(avt.url, avt.username, avt.password);
                        Statement statement = conn.createStatement();
                        String query = "SELECT user_id FROM testing_process.users WHERE full_name = \"" + avt.pr + "\";";

                        ResultSet resSet;
                        for(resSet = statement.executeQuery(query); resSet.next(); S = resSet.getString("user_id")) {
                            ;
                        }

                        query = "SELECT test_id FROM testing_process.tests WHERE name = \"" + Send_to_the_database.this.tf1.getText() + "\";";

                        for(resSet = statement.executeQuery(query); resSet.next(); test_id = resSet.getString("test_id")) {
                            ;
                        }

                        query = "SELECT id_version FROM testing_process.versions_of_the_system_components WHERE database_version = \"" + Send_to_the_database.this.tf5.getText() + "\" AND application_server_version = \"" + Send_to_the_database.this.tf6.getText() + "\";";
                        reader.l1.setText("");

                        for(resSet = statement.executeQuery(query); resSet.next(); id_version = resSet.getString("id_version")) {
                            ;
                        }

                        query = "INSERT INTO testing_process.result (recording_time_date, test_id, result, id_version, user_id) VALUES (\'" + Send_to_the_database.this.tf3.getText() + " " + Send_to_the_database.this.tf4.getText() + "\', \'" + test_id + "\', \'" + Send_to_the_database.this.tf2.getText() + "\', \'" + id_version + "\', \'" + S + "\');";
                        statement.executeUpdate(query);
                        conn.close();
                    } catch (SQLException var12) {
                        JOptionPane.showMessageDialog((Component)null, "Не удалось записать информацию в БД!");
                    }

                    Send_to_the_database.this.dispose();
                    if(Send_to_the_database.this.ColTest != 1 && Send_to_the_database.this.ColTest != 0) {
                        Send_to_the_database S3 = new Send_to_the_database("Сохранение результата");
                        S3.setVisible(true);
                        S3.setDefaultCloseOperation(3);
                        S3.setSize(280, 460);
                        S3.setResizable(false);
                        S3.setLocationRelativeTo((Component)null);
                    } else {
                        reader.a = "";
                    }
                }

                if(e.getSource() == Send_to_the_database.this.b2) {
                    ex = false;
                    if(reader.a.contains("завершился неудачно")) {
                        mm = Send_to_the_database.this.buffer.indexOf("завершился неудачно");
                        Send_to_the_database.this.buffer.replace(mm, mm + 21, "");
                        ex = true;
                    }

                    if(reader.a.contains("пройден") && !ex) {
                        mm = Send_to_the_database.this.buffer.indexOf("пройден");
                        Send_to_the_database.this.buffer.replace(mm, mm + 21, "");
                    }

                    reader.a = Send_to_the_database.this.buffer.toString();
                    Send_to_the_database.this.dispose();
                    if(Send_to_the_database.this.ColTest != 1 && Send_to_the_database.this.ColTest != 0) {
                        Send_to_the_database S2 = new Send_to_the_database("Сохранение результата");
                        S2.setVisible(true);
                        S2.setDefaultCloseOperation(3);
                        S2.setSize(280, 460);
                        S2.setResizable(false);
                        S2.setLocationRelativeTo((Component)null);
                    } else {
                        reader.a = "";
                    }
                }

                if(e.getSource() == Send_to_the_database.this.b3) {
                    Send_to_the_database.this.dispose();
                }
            } catch (Exception var13) {
                JOptionPane.showMessageDialog((Component)null, "Что-то пошло не так!");
            }

        }
    }
}
