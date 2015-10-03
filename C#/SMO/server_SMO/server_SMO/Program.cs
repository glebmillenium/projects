/*
 * Created by SharpDevelop.
 * User: Глеб
 * Date: 19.05.2015
 * Time: 0:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server_SMO
{
	class Program
	{
		
		public static void Main(string[] args)
		{
			// Устанавливаем для сокета локальную конечную точку
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);//локальнная конечная точка для соединения

            // Создаем сокет Tcp/Ip
            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            try
            {
                sListener.Bind(ipEndPoint);//связываем сокет с локал. конечной точкой
                sListener.Listen(10);//макс. число соединений ожидающих обработки

                // Начинаем слушать соединения
                while (true)
                {
                    Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);

                    // Программа приостанавливается, ожидая входящее соединение
                    Socket handler = sListener.Accept();
                    string data = null;

                    // Мы дождались клиента, пытающегося с нами соединиться
                    
                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    
                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    
                    if (data.IndexOf("<TheEnd>") > -1)
                    {
                        Console.WriteLine("Сервер завершил соединение с клиентом.");
                        break;
                    }
                    // Показываем данные на консоли
                    Console.Write("Полученный текст: " + data + "\n\n");
                    
                    
                    //  Делаем расчет данных СМО
                    try{
	                    string answer=answerToClient(data);
	                    
	                    // Отправляем ответ клиенту
	                    string reply =answer;
	                    byte[] msg = Encoding.UTF8.GetBytes(reply);
	                    handler.Send(msg);
	                    
	                    handler.Shutdown(SocketShutdown.Both);
	                    handler.Close();
                    }
                    catch{
                    	string reply ="не корректный ввод данных!";
                    	byte[] msg = Encoding.UTF8.GetBytes(reply);
	                    handler.Send(msg);
	                    
	                    handler.Shutdown(SocketShutdown.Both);
	                    handler.Close();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
		}
		
		public static string answerToClient(string data)  {
			DataFromClient input=new DataFromClient(data);
			//проводим действия
			string answer=null;
			string firstTask = Convert.ToString((new ProbabilityFreeToChanel(input.n,input.lyambda,input.t)).countProbability());//Решение первой задачи
			answer+="Вероятность того, что все каналы будут свободны "+firstTask+"\n";
			
			string secondTask="1";//Решение второй задачи
			ProbabilityOccupiedChanel ServerData= new ProbabilityOccupiedChanel(input.n,input.lyambda,input.t);
			while(true){
				ServerData.i++;//.i- номер ЭВМ
				secondTask = Convert.ToString(ServerData.countProbability());
				if(secondTask=="-1") break;
				answer+="Вероятность того что, "+ServerData.i+" канал будет занят "+secondTask+"\n";
			}
			
			
			//решение третей задачи
			answer+="Вероятность доли заявок получивших отказ(все ЭВМ заняты) "
				+Convert.ToString((new ProbabilityOfFailure(input.n,input.lyambda,input.t)).countProbability())+"\n";
			//решение четвертой задачи
			double r_obs=1-(new ProbabilityOfFailure(input.n,input.lyambda,input.t)).countProbability();
			answer+="Относительная пропускная способность: "+Convert.ToString(r_obs)+"\n";
			//решение пятой задачи
			answer+="Абсолютная пропускная способность: "+Convert.ToString(input.lyambda*r_obs)+" заявок в минуту\n";
			//решение шестой задачи
			answer+="Среднее число ЭВМ занятых обслуживанием: "+Convert.ToString(r_obs*input.lyambda*input.t)+"\n";
			//решение седьмой задачи
			
			answer+="Чтобы увеличить пропускную способность в 2 раза, необходимо дополнительно задействовать еще "
				+Convert.ToString((new ProbabilityOfFailure(input.n,input.lyambda,input.t)).toIncreaseCapacity_x2()-input.n)+" ЭВМ\n";
			
			return answer;
		}

	}
}