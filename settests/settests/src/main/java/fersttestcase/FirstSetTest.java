package fersttestcase;
import org.openqa.selenium.WebDriver;
import java.util.concurrent.TimeUnit;
import org.junit.Test;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.By;
import javax.swing.*;
public class FirstSetTest
{
    @Test
    public String setTest() throws InterruptedException
    {
        String strlog = "";
        try {
            System.setProperty("webdriver.chrome.driver", "C:\\JetBrains\\chromedriver.exe");
            WebDriver driver = new ChromeDriver();
            driver.get("http://svrw-asusps-apt.svrw.oao.rzd/");
            driver.manage().window().maximize();
            driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
            strlog += "Контрольный пример №1\nТест № 1\n";
            System.out.println("<------------Контрольный пример №1------------>");
            System.out.println("<------------Тест № 1 запущен------------>");
            System.out.println("1.Входим в систему");
            strlog += " 1.Входим в систему";
            String link = driver.findElement(By.xpath("html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[2]/li[2]/a")).getAttribute("href");
            driver.get(link);
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[1]/div/input", "Ясинская Анна Васильевна");
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[2]/div/input", "Aysi=123");
            driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[4]/div/button")).click();
            Thread.sleep(2000);
            //Создаем учётную запись, указав необходимые сведения
            strlog += "\n" + " 2.Создаем учётную запись, указав необходимые сведения";
            System.out.println("2.Создаем учётную запись, указав необходимые сведения");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[1]/li[4]/a/span[1]");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[1]/li[4]/ul/li[3]/a");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[2]/td/div/div/table/thead/tr/th[1]/a/span");
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[1]/div/input", "IvanovVN");
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[2]/div/input", "qwer1234");
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[3]/div/input", "qwer1234");
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[4]/div/span/input[2]", "Иванов Василий Никитич");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[4]/div/span/span/div/span/div/p");
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[5]/div/div/input", "13.10.2016");
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[6]/div/input", "+74954746494");
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[7]/div/input", "ivanov@mail.ru");
            driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[8]/div/button")).click();
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[8]/div/ul/li/div/div/div/span[2]/input[2]", "ТЧЭ-1 МОСКВА");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[8]/div/ul/li/div/div/div/span[2]/span/div/span/div/p");
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[9]/div/textarea", "Новый пользователь");
            driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[10]/div/button")).click();
            Core.fillingForm(driver, ".//*[@id='usersIndex-user-tab']/div/div/input", "IvanovVN");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[2]/div/button");
            //добавляем пользователю роли
            strlog += "\n" + " 3.Добавляем пользователю роли";
            System.out.println("3.Добавляем пользователю роли");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr/td[1]/div/button");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr/td[1]/div/ul/li[5]/a");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[2]/div/div/div/div[1]/button[1]");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[3]/div/button");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div[3]/div/button");
            //Выйдем из системы и зайдем повторно, используя созданную нами учётную запись
            strlog += "\n" + " 4.Выйдем из системы";
            System.out.println("4.Выйдем из системы");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[2]/li[3]/a/span[3]");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[2]/li[3]/ul/li[2]/a/span[2]");
            Core.pressPlusJS(driver, "html/body/div[3]/div/form/div[3]/div/button[1]");
            Thread.sleep(2000);
            strlog += "\n" + " 5.Зайдем повторно, используя созданную нами учётную запись";
            System.out.println("5.Зайдем повторно, используя созданную нами учётную запись");
            driver.get("http://svrw-asusps-apt.svrw.oao.rzd/");
            link = driver.findElement(By.xpath("html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[2]/li[2]/a")).getAttribute("href");
            driver.get(link);
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[1]/div/input", "IvanovVN");
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[2]/div/input", "qwer1234");
            driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[4]/div/button")).click();
            //удаляем пользователя, которого создали
            strlog += "\n" + " 6.Удаляем пользователя, которого создали";
            System.out.println("6.Удаляем пользователя, которого создали");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[2]/li[3]/a/span[3]");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[2]/li[3]/ul/li[2]/a/span[2]");
            Core.pressPlusJS(driver, "html/body/div[3]/div/form/div[3]/div/button[1]");
            driver.get("http://svrw-asusps-apt.svrw.oao.rzd/");
            link = driver.findElement(By.xpath("html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[2]/li[2]/a")).getAttribute("href");
            driver.get(link);
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[1]/div/input", "Ясинская Анна Васильевна");
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[2]/div/input", "Aysi=123");
            driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[4]/div/button")).click();
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[1]/li[4]/a/span[1]");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[1]/li[4]/ul/li[3]/a");
            Core.fillingForm(driver, ".//*[@id='usersIndex-user-tab']/div/div/input", "IvanovVN");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[2]/div/button");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr/td[1]/div/button");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr/td[1]/div/ul/li[6]/a");
            Core.pressPlusJS(driver, "html/body/div[3]/div/form/div[3]/div/button[1]");
            driver.get("http://svrw-asusps-apt.svrw.oao.rzd/");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[2]/li[3]/a/span[3]");
            Core.pressPlusJS(driver, "html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[2]/li[3]/ul/li[2]/a/span[2]");
            Core.pressPlusJS(driver, "html/body/div[3]/div/form/div[3]/div/button[1]");
            strlog += "\n" + " Тест 1.1 пройден!";
            System.out.println("<------------Тест № 1  пройден------------>");

            driver.close();
        }catch (Exception ex) {
            JOptionPane.showMessageDialog(null, "Тест не прошел!");
            strlog = "Тест 1.1 завершился неудачно!";
        }
        return strlog;
    }
}
