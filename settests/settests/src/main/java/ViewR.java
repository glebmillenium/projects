
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.IOException;
import java.io.PrintWriter;
import javax.swing.*;
import javax.swing.border.Border;
import javax.swing.border.TitledBorder;

public class ViewR extends JFrame {
    JPanel panel;
    JButton b1, b2, b3, b4, b5, b6, b7;
    static JTextArea l2;
    static JCheckBox Box1, Box2, Box3, Box4, Box5, Box6;

    public ViewR(String s) {
        super(s);
        this.setLayout(new FlowLayout());
        ViewR.handler hand = new ViewR.handler();
        this.panel = new JPanel();
        Border var19 = BorderFactory.createEtchedBorder();
        TitledBorder titled = BorderFactory.createTitledBorder(var19, "Настройка вывода результата");
        this.panel.setBorder(titled);
        this.panel.setLayout(new GridLayout(3, 6));
        this.l2 = new JTextArea("Пусто", 20, 55);
        Box1 = new JCheckBox("ID результата");
        Box2 = new JCheckBox("Дата и время записи");
        Box3 = new JCheckBox("Тест");
        Box4 = new JCheckBox("Результат");
        Box5 = new JCheckBox("Версия компонентов АСУ СПС");
        Box6 = new JCheckBox("Пользователь");
        b7 = new JButton("Вывести результаты");
        this.b1 = new JButton("Выбрать фильтр");
        this.b2 = new JButton("Отметить/снять все");
        this.b3 = new JButton("Очистить");
        this.b4 = new JButton("Сохранить в файл");
        this.b5 = new JButton("Информация о тестах");
        this.b6 = new JButton("Вернуться");
        add(panel);
        this.add(new JScrollPane(l2));
        this.panel.add(Box1);
        this.panel.add(Box2);
        this.panel.add(Box3);
        this.panel.add(Box4);
        this.panel.add(Box6);
        this.panel.add(Box5);
        this.panel.add(b2);
        this.panel.add(b1);
        this.panel.add(b7);
        this.add(b3);
        this.add(b4);
        this.add(b5);
        this.add(b6);
        this.b1.addActionListener(hand);
        this.b2.addActionListener(hand);
        this.b3.addActionListener(hand);
        this.b4.addActionListener(hand);
        this.b5.addActionListener(hand);
        this.b6.addActionListener(hand);
        this.b7.addActionListener(hand);
    }

    public class handler implements ActionListener {
        public handler() {
        }

        public void actionPerformed(ActionEvent e) {
            try {

                if(e.getSource() == ViewR.this.b1) {
                    FConclusion fc = new FConclusion("Фильтры");
                    fc.setVisible(true);
                    fc.setDefaultCloseOperation(3);
                    fc.setSize(250, 150);
                    fc.setResizable(false);
                    fc.setLocationRelativeTo((Component)null);
                }

                if(e.getSource() == ViewR.this.b2) {
                    boolean a = false;
                    if( ViewR.Box1.isSelected() == a || ViewR.Box2.isSelected() == a || ViewR.Box3.isSelected() == a || ViewR.Box4.isSelected() == a
                            || ViewR.Box5.isSelected() == a || ViewR.Box6.isSelected() == a)
                        a = true;
                        ViewR.Box1.setSelected(a);
                        ViewR.Box2.setSelected(a);
                        ViewR.Box3.setSelected(a);
                        ViewR.Box4.setSelected(a);
                        ViewR.Box5.setSelected(a);
                        ViewR.Box6.setSelected(a);

                }
                if(e.getSource() == ViewR.this.b3) {
                    ViewR.l2.setText("");
                }
                if(e.getSource() == ViewR.this.b4) {
                        //Определяем файл
                        File file = new File("C://Users/ivc_KrivosheevIA/Desktop/Отчет.txt");
                        try {
                            //проверяем, что если файл не существует то создаем его
                            if(!file.exists()){
                                file.createNewFile();
                            }
                            //PrintWriter обеспечит возможности записи в файл
                            PrintWriter out = new PrintWriter(file.getAbsoluteFile());
                            try {
                                //Записываем текст у файл
                                out.print(ViewR.l2.getText());
                            } finally {
                                //После чего мы должны закрыть файл
                                //Иначе файл не запишется
                                out.close();
                            }
                             } catch(IOException ex) {
                                throw new RuntimeException(ex);
                             }
                }
                if(e.getSource() == ViewR.this.b5) {
                    ViewR.this.dispose();
                    InfoTests inf = new InfoTests("Информация о тестах");
                    inf.setVisible(true);
                    inf.setDefaultCloseOperation(3);
                    inf.setSize(200, 150);
                    inf.setResizable(false);
                    inf.setLocationRelativeTo((Component)null);
                }
                if(e.getSource() == ViewR.this.b6) {
                    ViewR.this.dispose();
                    Option ex = new Option("Options");
                    ex.setVisible(true);
                    ex.setDefaultCloseOperation(3);
                    ex.setSize(200, 150);
                    ex.setResizable(false);
                    ex.setLocationRelativeTo((Component)null);
                }
                if(e.getSource() == ViewR.this.b7) {
                    ViewR.l2.setText("Вот тебе результ");
                }
            } catch (Exception var3) {
                JOptionPane.showMessageDialog((Component)null, "Что-то пошло не так!");
            }

        }
    }
}
