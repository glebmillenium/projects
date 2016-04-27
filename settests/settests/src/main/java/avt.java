import com.mysql.jdbc.Connection;
import java.awt.Component;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.ResultSet;
import java.sql.Statement;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

public class avt extends JFrame {
    JButton b3, b1;
    JTextField l2;
    JPasswordField l3;
    static String pr;
    static String url = "jdbc:mysql://localhost:3306/mysql?useSSL=false";
    static String username = "nextuser";
    static String password = "3yxbs6";
    avt.handler hand = new avt.handler();

    public avt(String s) {
        super(s);
        this.setLayout(new FlowLayout());
        this.l2 = new JTextField("admin", 16);
        this.l3 = new JPasswordField("370061", 16);
        this.l3.setToolTipText("Введите пароль");
        this.l2.setToolTipText("Введите логин");
        this.b3 = new JButton("Вход");
        this.b1 = new JButton("Помощь");
        this.add(this.l2);
        this.add(this.l3);
        this.add(this.b3);
        this.add(this.b1);
        this.b3.addActionListener(this.hand);
        this.b1.addActionListener(this.hand);
    }

    public class handler implements ActionListener {
        public handler() {
        }

        public void actionPerformed(ActionEvent e) {
            try {
                if(e.getSource() == avt.this.b3) {
                    String ex = avt.this.l2.getText();
                    String bb = new String(avt.this.l3.getPassword());
                    DBProcessor db = new DBProcessor();
                    Connection conn = db.getConnection(avt.url, avt.username, avt.password);
                    Statement statement = conn.createStatement();
                    String query = "SELECT full_name FROM testing_process.users WHERE full_name = \"" + ex + "\" AND password = \"" + bb + "\";";
                    ResultSet resSet = statement.executeQuery(query);

                    for(avt.pr = ""; resSet.next(); avt.pr = resSet.getString("full_name")) {

                    }

                    conn.close();
                    if(avt.pr != "") {
                        JOptionPane.showMessageDialog(null, "Вы зашли как " + avt.pr);
                        avt.this.dispose();
                        Option o = new Option("Options");
                        o.setVisible(true);
                        o.setDefaultCloseOperation(3);
                        o.setSize(200, 150);
                        o.setResizable(false);
                        o.setLocationRelativeTo(null);
                    } else {
                        JOptionPane.showMessageDialog(null, "Неверная пара - логин и пароль");
                    }
                }
                if(e.getSource() == avt.this.b1) {
                    if(avt.pr != "") {
                        dispose();
                        Help h = new Help("Help!");
                        h.setVisible(true);
                        h.setDefaultCloseOperation(3);
                        h.setSize(200, 150);
                        h.setResizable(false);
                        h.setLocationRelativeTo(null);
                    } else {
                        JOptionPane.showMessageDialog(null, "Неверная пара - логин и пароль");
                    }
                }
            } catch (Exception var10) {
                JOptionPane.showMessageDialog(null, "Что-то пошло не так!");
            }

        }
    }
}
