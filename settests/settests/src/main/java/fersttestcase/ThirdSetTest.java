package fersttestcase;

import fersttestcase.Core;
import org.junit.Assert;
import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.ui.Select;
import org.openqa.selenium.chrome.ChromeDriver;

import javax.swing.*;
import java.util.concurrent.TimeUnit;


public class ThirdSetTest {

    @Test
    public String ThirdSetTest() throws InterruptedException {
        String str = "";
        try{
            System.setProperty("webdriver.chrome.driver", "C:\\JetBrains\\chromedriver.exe");
            WebDriver driver = new ChromeDriver();
            driver.get("http://svrw-asusps-apt.svrw.oao.rzd/");
            driver.manage().window().maximize();
            driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
            str += "Контрольный пример №1";
            System.out.println("<------------Контрольный пример №1------------>");
            str += "\n" +"Тест № 3  запущен";
            System.out.println("<------------Тест № 3  запущен------------>");
            str += "\n" +"1.Входим в систему";
            System.out.println("1.Входим в систему");
            String link = driver.findElement(By.xpath("html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[2]/li[2]/a")).getAttribute("href");
            driver.get(link);
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[1]/div/input", "Ясинская Анна Васильевна");
            Core.fillingForm(driver, "html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[2]/div/input", "Aysi=123");
            driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[4]/div/button")).click();
            Thread.sleep(1000);

            System.out.println("2.Откроем в главном меню вкладку «Персонал», выберем одноимённый пункт в списке");
            str += "\n" +"2.Откроем в главном меню вкладку «Персонал», выберем одноимённый пункт в списке";
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[1]/li[3]/a/span[2]");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[1]/td/div/div/div[2]/ul[1]/li[3]/ul/li[1]/a");

            System.out.println("3.Настроим расширенный фильтр");
            str += "\n" +"3.Настроим расширенный фильтр";
            new Select(driver.findElement(By.xpath("//div[@id='personalIndex-filter-tab']/div/div/select"))).selectByVisibleText("(Все)");
            new Select(driver.findElement(By.xpath(".//*[@id='personalIndex-filter-tab']/div[2]/div/select"))).selectByVisibleText("(Все)");
            Core.pressPlusJS(driver,".//*[@id='personalIndex-filter-tab']/div[4]/div/div/div/div[1]/button");
            Core.pressPlusJS(driver,".//*[@id='personalIndex-filter-tab']/div[4]/div/div/div/div[1]/div/div/div/div[1]/button[1]");
            Core.pressPlusJS(driver,".//*[@id='personalIndex-filter-tab']/div[4]/div/div/div/div[1]/div/button[1]");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div/div[2]/form/div[2]/div/button");
            System.out.println("4.Выбераем сотрудника из списка и нажимаем на кнопку с чёрным треугольником");
            str += "\n" +"4.Выбераем сотрудника из списка и нажимаем на кнопку с чёрным треугольником";
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr[1]/td[1]/div/button");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div/table/tbody/tr[1]/td[1]/div/ul/li[1]/a");
            System.out.println("5.Жмем <добавить>");
            str += "\n" +"5.Жмем <добавить>";
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/ul/li[7]/a");
            Core.pressPlusJS(driver,".//*[@id='personalDetail-personalPsychologist-tab']/div/table/thead/tr/th[1]/a");
            System.out.println("6.Жмем <добавить ПФО>");
            str += "\n" +"6.Жмем <добавить ПФО>";
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/button");
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/table/tbody/tr[1]/td[3]/select");
            System.out.println("7.Заполняем одну из форм форму");
            str += "\n" +"7.Заполняем одну из форм форму";
            new Select(driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/table/tbody/tr[1]/td[3]/select"))).selectByVisibleText("1");
            System.out.println("8.Жмем <применить>");
            str += "\n" +"8.Жмем <применить>";
            Core.pressPlusJS(driver,"html/body/table/tbody/tr[2]/td/div/div[2]/div[2]/form/div/div/button");
            System.out.println("9.Удостоверимя, что запись добавить не удалось");
            str += "\n" +"9.Удостоверимя, что запись добавить не удалось";
            Assert.assertEquals("Редактирование", driver.findElement(By.xpath("html/body/table/tbody/tr[2]/td/div/div[2]/div[1]/span[2]")).getText());
            System.out.println("<------------Тест № 3  пройден------------>");
            str += "\n" +"Тест 1.3 пройден!";
            driver.close();
        }catch (Exception ex) {
            JOptionPane.showMessageDialog(null, "Тест не прошел!");
            str = "Тест 1.3 завершился неудачно!";
        }
        return str;
    }
}
