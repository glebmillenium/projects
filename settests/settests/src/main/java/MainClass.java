
import java.awt.Component;

public class MainClass {
    public MainClass() {
           
    }

    public static void main(String[] args) {
        avt a = new avt("Вход");
        a.setVisible(true);
        a.setDefaultCloseOperation(3);
        a.setSize(250, 180);
        a.setResizable(false);
        a.setLocationRelativeTo((Component)null);
    }
}
