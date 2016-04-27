
import java.awt.Component;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.*;

public class FConclusion extends JFrame {
    JButton b2;
    JLabel jl1;
    JComboBox cb;
    FConclusion.handler hand = new FConclusion.handler();

    public FConclusion(String s) {
        super(s);
        this.setLayout(new FlowLayout());
        String[] items = new String[]{"Дата", "Версии компонентов АСУ СПС", "ФИО пользователя", "Результат тестирования", "Список последних тестирований"};
        this.cb = new JComboBox(items);
        this.b2 = new JButton("Далее");
        this.jl1 = new JLabel("\nВыберите фильтр:\n");
        this.add(this.jl1);
        this.add(cb);
        this.add(this.b2);
        this.b2.addActionListener(this.hand);
    }

    public class handler implements ActionListener {
        public handler() {
        }

        public void actionPerformed(ActionEvent e) {
            try {
                String cb = (String)FConclusion.this.cb.getSelectedItem();
                if(e.getSource() == FConclusion.this.b2) {
                    if(cb == "Дата") {
                        FConclusion.this.dispose();
                        Data ex = new Data("Фильтрация по Дате");
                        ex.setVisible(true);
                        ex.setDefaultCloseOperation(3);
                        ex.setSize(200, 220);
                        ex.setResizable(false);
                        ex.setLocationRelativeTo((Component) null);
                    }
                    if(cb == "Версии компонентов АСУ СПС") {
                        FConclusion.this.dispose();
                        reader ex = new reader("Тестирование");
                        ex.setVisible(true);
                        ex.setDefaultCloseOperation(3);
                        ex.setSize(400, 640);
                        ex.setResizable(false);
                        ex.setLocationRelativeTo((Component) null);
                    }
                    if(cb == "ФИО пользователя") {
                        FConclusion.this.dispose();
                        reader ex = new reader("Тестирование");
                        ex.setVisible(true);
                        ex.setDefaultCloseOperation(3);
                        ex.setSize(400, 640);
                        ex.setResizable(false);
                        ex.setLocationRelativeTo((Component) null);
                    }
                    if(cb == "Результат тестирования") {
                        FConclusion.this.dispose();
                        reader ex = new reader("Тестирование");
                        ex.setVisible(true);
                        ex.setDefaultCloseOperation(3);
                        ex.setSize(400, 640);
                        ex.setResizable(false);
                        ex.setLocationRelativeTo((Component) null);
                    }
                    if(cb == "Список последних тестирований") {
                        FConclusion.this.dispose();
                        reader ex = new reader("Тестирование");
                        ex.setVisible(true);
                        ex.setDefaultCloseOperation(3);
                        ex.setSize(400, 640);
                        ex.setResizable(false);
                        ex.setLocationRelativeTo((Component) null);
                    }
                }
            } catch (Exception var3) {
                JOptionPane.showMessageDialog((Component)null, "Что-то пошло не так!");
            }

        }
    }
}
