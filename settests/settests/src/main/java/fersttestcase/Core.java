package fersttestcase;

import org.openqa.selenium.By;
import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import java.util.concurrent.TimeUnit;


public class Core {
    public static void fillingForm(WebDriver driver, String text, String giveKeys) {
        WebElement form = driver.findElement(By.xpath(text));
        form.clear();
        form.sendKeys(giveKeys);
    }

    public static void pressPlusJS(WebDriver driver, String text) {
        driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
        WebElement serchlink = driver.findElement(By.xpath(text));
        ((JavascriptExecutor) driver).executeScript("arguments[0].click()", serchlink);
    }


}