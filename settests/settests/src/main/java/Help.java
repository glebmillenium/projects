
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.*;

public class Help extends JFrame {
    JButton b3;
    JLabel jl1;
    handler hand = new handler();

    public Help(String s) {
        super(s);
        this.setLayout(new FlowLayout());
        this.jl1 = new JLabel("Никто тебе не поможет!");
        this.b3 = new JButton("Вход");
        this.add(this.jl1);
        this.add(this.b3);
        this.b3.addActionListener(this.hand);
    }
    public class handler implements ActionListener {
        public handler() {
        }
        public void actionPerformed(ActionEvent e) {
            try {
                if(e.getSource() == b3) {


                        dispose();
                        Option o = new Option("Options");
                        o.setVisible(true);
                        o.setDefaultCloseOperation(3);
                        o.setSize(200, 150);
                        o.setResizable(false);
                        o.setLocationRelativeTo(null);

                }

            } catch (Exception var10) {
                JOptionPane.showMessageDialog(null, "Что-то пошло не так!");
            }

        }
    }
}
