package fersttestcase;

import org.junit.Assert;
import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

import javax.swing.*;
import java.util.concurrent.TimeUnit;

public class SecondSetTest {
    @Test
    public String SecondSetTest() throws InterruptedException {
        String str ="";
        try{
            System.setProperty("webdriver.chrome.driver", "C:\\JetBrains\\chromedriver.exe");
            WebDriver driver = new ChromeDriver();
            driver.get("http://svrw-asusps-apt.svrw.oao.rzd/");
            driver.manage().window().maximize();
            driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
            str += "Контрольный пример №1";
            System.out.println("<------------Контрольный пример №1------------>");
            str += "\n" +"Тест № 2  запущен";
            System.out.println("<------------Тест № 2  запущен------------>");
            str += "\n" +"1.Вводим неверные имя пользователя и пароль";
            System.out.println("1.Вводим неверные имя пользователя и пароль");
            String link = driver.findElement(By.xpath("html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[2]/li[2]/a")).getAttribute("href");
            driver.get(link);
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[1]/div/input", "iuhi923h");
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[2]/div/input", "987fe7hq)");
            driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[4]/div/button")).click();
            str += "\n" +"2.Проверяем на отказ в доступе";
            System.out.println("2.Проверяем на отказ в доступе");
            Assert.assertEquals("Неверное имя пользователя или пароль.", driver.findElement(By.cssSelector("h4.message.text-info")).getText());
            str += "\n" +"Тест 1.2 пройден!";
            System.out.println("<------------Тест № 2  пройден------------>");
            driver.close();
        }catch (Exception ex) {
            JOptionPane.showMessageDialog(null, "Тест не прошел!");
            str = "Тест 1.2 завершился неудачно!";
        }
        return str;
    }
}

