package secondtestcase;


import fersttestcase.Core;
import org.junit.Assert;
import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.Select;

import javax.swing.*;
import java.util.concurrent.TimeUnit;

public class FirstSetTest {


    @Test
    public String setTest() throws InterruptedException {
        String str = "";
        try{
            System.setProperty("webdriver.chrome.driver", "C:\\JetBrains\\chromedriver.exe");
            WebDriver driver = new ChromeDriver();
            driver.get("http://svrw-asusps-apt.svrw.oao.rzd/");
            driver.manage().window().maximize();
            driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
            System.out.println("<------------Контрольный пример №2------------>");
            System.out.println("<------------Тест № 1  запущен------------>");
            System.out.println("1.Входим в систему");
            str += "Контрольный пример №2 \nТест № 1  запущен \n1.Входим в систему";
            String link = driver.findElement(By.xpath("html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[2]/li[2]/a")).getAttribute("href");
            driver.get(link);
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[1]/div/input", "Ясинская Анна Васильевна");
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[2]/div/input", "Aysi=123");
            driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[4]/div/button")).click();
            Thread.sleep(2000);

            System.out.println("2.Открываем <Персонал>");
            str += "\n" +"2.Открываем <Персонал>";
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[1]/li[3]/a/span[2]");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[1]/li[3]/ul/li[1]/a");

            System.out.println("3.Создаем нового");
            str += "\n" +"3.Создаем нового";
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div/table/thead/tr/th[1]/a/span");

            System.out.println("4.Заполняем формы");
            str += "\n" +"4.Заполняем формы";
            Core.fillingForm(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[1]/div/input","Григоров");
            Core.fillingForm(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[2]/div/input","Иван");
            Core.fillingForm(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[3]/div/input","Ивановский");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[4]/div/div/span/span");
            Core.pressPlusJS(driver,"html/body/div[3]/div/div[1]/table/tbody/tr[2]/td[4]");
            Core.fillingForm(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[5]/div/input","321-456-899 34");
            Core.fillingForm(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[6]/div/textarea","Новый сотрудник");

            System.out.println("5.Добавляем должность");
            str += "\n" +"5.Добавляем должность";
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[7]/div/div/button");

            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[7]/div/div/table/tbody/tr/td[2]/div/span/span");
            Core.pressPlusJS(driver,"html/body/div[4]/div/div[1]/table/tbody/tr[3]/td[3]");

            new Select(driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[7]/div/div/table/tbody/tr/td[3]/select"))).selectByVisibleText("Ведущий инженер");
            System.out.println("6.Сохраняем");
            str += "\n" +"6.Сохраняем";
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[9]/div/button");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div[4]/a");
            System.out.print("7.Ищем добавленного сотрудника");
            str += "\n" +"7.Ищем добавленного сотрудника";
            Core.fillingForm(driver,".//*[@id='personalIndex-personal-tab']/div/div/input","Григоров");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[2]/div/button");
            Assert.assertEquals("Григоров", driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr[2]/td[3]")).getText());
            Assert.assertEquals("Иван", driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr[2]/td[4]")).getText());
            Assert.assertEquals("Ивановский", driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr[2]/td[5]")).getText());
            Assert.assertEquals("10.03.2016", driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr[2]/td[6]")).getText());
            Assert.assertEquals("Ведущий инженер", driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr[2]/td[9]")).getText());
            System.out.println("...Сотрудник найден");
            System.out.println("8.Отменяем его должность");
            str += "\n" +"8.Отменяем его должность";
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr[2]/td[1]/div/button");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr[2]/td[1]/div/ul/li[4]/a");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[7]/div/div/table/tbody/tr/td[1]/button");
            Core.pressPlusJS(driver,"html/body/div[5]/div/form/div[3]/div/button[1]");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[9]/div/button");
            System.out.println("9.Удаляем сотрудника");
            str += "\n" +"9.Удаляем сотрудника";
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr[2]/td[1]/div/button");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr[2]/td[1]/div/ul/li[5]/a");
            Core.pressPlusJS(driver,"html/body/div[4]/div/form/div[3]/div/button[1]");
            System.out.println("<------------Основной тест завершен------------>");
            System.out.println("<------------Дополнительно------------>");
            System.out.println("1.Добавим новую должность");
            str += "\n" +"--Основной тест завершен\nДополнительно\n1.Добавим новую должность";
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[1]/li[4]/a");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[1]/li[4]/ul/li[4]/a");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div/table/thead/tr/th[1]/a");
            Core.fillingForm(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[1]/div/span/input[2]","Маляр");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[1]/div/span/span/div/span/div/p");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[2]/div/div/label/input");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[5]/div/button");
            Assert.assertEquals("Маляр", driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr/td[2]")).getText());
            System.out.println("2.Удалим новую должность");
            str += "\n" +"2.Удалим новую должность";
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr/td[1]/div/button");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr/td[1]/div/ul/li[2]/a");
            Core.pressPlusJS(driver,"html/body/div[3]/div/form/div[3]/div/button[1]");
            System.out.println("<------------Тест № 1  пройден------------>");
            str += "\n" +"Тест 2.1 пройден!";

            driver.close();
        }catch (Exception ex) {
            JOptionPane.showMessageDialog(null, "Тест не прошел!");
            str = "Тест 2.1 завершился неудачно!";
        }
        return str;
    }
}
