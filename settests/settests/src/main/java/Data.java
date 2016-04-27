import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
public class Data extends JFrame {
    JButton b1, b2;
    JTextField t1, t2;
    JLabel jl, jl1, jl2;
    Data.handler hand = new Data.handler();
    public Data(String s) {
        super(s);
        this.setLayout(new FlowLayout());
        jl1 = new JLabel("Начиная с");
        jl2 = new JLabel("Заканчивая");
        jl = new JLabel("Введите диапазон времени");
        this.t1 = new JTextField("", 12);
        this.t2 = new JTextField("", 12);
        this.b1 = new JButton("Ок");
        this.b2 = new JButton("Отмена");
        this.t1.setToolTipText("Формат ввода: \"YYYY-MM-DD HH:MM:SS\"");
        this.t2.setToolTipText("Формат ввода: \"YYYY-MM-DD HH:MM:SS\"");
        add(jl);
        add(jl1);
        add(t1);
        add(jl2);
        add(t2);
        this.add(this.b1);
        this.add(this.b2);
        this.b2.addActionListener(this.hand);
    }
    public class handler implements ActionListener {
        public handler() {
        }
        public void actionPerformed(ActionEvent e) {
            try {
                if(e.getSource() == Data.this.b2) {
                    Data.this.dispose();
                }
            } catch (Exception var6) {
                JOptionPane.showMessageDialog((Component)null, "Что-то пошло не так...");
            }
        }
    }
}
