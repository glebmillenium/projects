//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by Fernflower decompiler)
//

import java.awt.Component;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;

public class Option extends JFrame {
    JButton b3;
    JButton b2;
    JLabel jl1;
    Option.handler hand = new Option.handler();

    public Option(String s) {
        super(s);
        this.setLayout(new FlowLayout());
        this.b3 = new JButton("Тестирование");
        this.b2 = new JButton("Просмотр результатов");
        this.jl1 = new JLabel("\nВыберите режим:\n");
        this.add(this.jl1);
        this.add(this.b3);
        this.add(this.b2);
        this.b3.addActionListener(this.hand);
        this.b2.addActionListener(this.hand);
    }

    public class handler implements ActionListener {
        public handler() {
        }

        public void actionPerformed(ActionEvent e) {
            try {
                if(e.getSource() == Option.this.b3) {
                    Option.this.dispose();
                    reader ex = new reader("Тестирование");
                    ex.setVisible(true);
                    ex.setDefaultCloseOperation(3);
                    ex.setSize(400, 640);
                    ex.setResizable(false);
                    ex.setLocationRelativeTo((Component)null);
                }

                if(e.getSource() == Option.this.b2) {
                    Option.this.dispose();
                    ViewR ex1 = new ViewR("Просмотр результатов");
                    ex1.setVisible(true);
                    ex1.setDefaultCloseOperation(3);
                    ex1.setSize(660, 580);
                    ex1.setResizable(false);
                    ex1.setLocationRelativeTo((Component)null);
                }
            } catch (Exception var3) {
                JOptionPane.showMessageDialog((Component)null, "Что-то пошло не так!");
            }

        }
    }
}
