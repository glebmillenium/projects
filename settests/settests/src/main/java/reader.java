//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by Fernflower decompiler)
//

import fersttestcase.FirstSetTest;
import fersttestcase.SecondSetTest;
import fersttestcase.ThirdSetTest;
import java.awt.Component;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;

public class reader extends JFrame {
    JButton b3;
    JButton b2;
    JButton b1;
    JButton b4;
    static JTextArea l1;
    JComboBox comboBox;
    static String a;
    reader.handler hand = new reader.handler();

    public reader(String s) {
        super(s);
        this.setLayout(new FlowLayout());
        this.b3 = new JButton("Начать тестирование");
        this.b2 = new JButton("Занести результаты в БД");
        this.b1 = new JButton("Очистить");
        this.b4 = new JButton("Сменить режим");
        String[] items = new String[]{"Контрольный пример №1", "Тест №1.1", "Тест №1.2", "Тест №1.3", "Контрольный пример №2", "Тест №2.1"};
        this.comboBox = new JComboBox(items);
        a = "";
        this.add(this.comboBox);
        this.add(this.b3);
        this.b3.addActionListener(this.hand);
        this.b2.addActionListener(this.hand);
        this.b1.addActionListener(this.hand);
        this.b4.addActionListener(this.hand);
        l1 = new JTextArea("", 30, 30);
        this.add(new JScrollPane(l1));
        this.add(this.b1);
        this.add(this.b2);
        this.add(this.b4);
    }

    public class handler implements ActionListener {
        public handler() {
        }

        public void actionPerformed(ActionEvent e) {
            try {
                String ex = (String)reader.this.comboBox.getSelectedItem();
                if(e.getSource() == reader.this.b1) {
                    reader.l1.setText("");
                }

                if(e.getSource() == reader.this.b2) {
                    if(reader.a != "") {
                        Send_to_the_database no = new Send_to_the_database("Сохранение результата");
                        no.setVisible(true);
                        no.setDefaultCloseOperation(3);
                        no.setSize(280, 460);
                        no.setResizable(false);
                        no.setLocationRelativeTo((Component)null);
                    } else {
                        JOptionPane.showMessageDialog((Component)null, "Пройдите процесс тестирования!");
                    }
                }

                if(e.getSource() == reader.this.b4) {
                    reader.this.dispose();
                    Option no1 = new Option("Options");
                    no1.setVisible(true);
                    no1.setDefaultCloseOperation(3);
                    no1.setSize(200, 150);
                    no1.setResizable(false);
                    no1.setLocationRelativeTo((Component)null);
                }

                if(e.getSource() == reader.this.b3) {
                    reader.a = "";
                    FirstSetTest no2;
                    if(ex == "Контрольный пример №1") {
                        no2 = new FirstSetTest();
                        reader.a = no2.setTest();
                        reader.a = reader.a + "\n________________________________";
                        reader.l1.setText(reader.a);
                        SecondSetTest yes = new SecondSetTest();
                        reader.a = reader.a + "\n" + yes.SecondSetTest();
                        reader.a = reader.a + "\n________________________________";
                        reader.l1.setText(reader.a);
                        ThirdSetTest yesno = new ThirdSetTest();
                        reader.a = reader.a + "\n" + yesno.ThirdSetTest();
                        reader.a = reader.a + "\n________________________________";
                        reader.l1.setText(reader.a);
                    }

                    if(ex == "Тест №1.1") {
                        no2 = new FirstSetTest();
                        reader.a = no2.setTest();
                        reader.l1.setText(reader.a);
                    }

                    if(ex == "Тест №1.2") {
                        SecondSetTest no3 = new SecondSetTest();
                        reader.a = no3.SecondSetTest();
                        reader.l1.setText(reader.a);
                    }

                    if(ex == "Тест №1.3") {
                        ThirdSetTest no4 = new ThirdSetTest();
                        reader.a = no4.ThirdSetTest();
                        reader.l1.setText(reader.a);
                    }

                    secondtestcase.FirstSetTest no5;
                    if(ex == "Контрольный пример №2") {
                        no5 = new secondtestcase.FirstSetTest();
                        reader.a = no5.setTest();
                        reader.a = reader.a + "\n________________________________";
                        reader.l1.setText(reader.a);
                    }

                    if(ex == "Тест №2.1") {
                        no5 = new secondtestcase.FirstSetTest();
                        reader.a = no5.setTest();
                        reader.l1.setText(reader.a);
                    }

                    int no6 = reader.a.split("неудачно").length - 1;
                    int yes1 = reader.a.split("пройден").length - 1;
                    int yesno1 = yes1 + no6;
                    if(yesno1 > 1) {
                        reader.l1.setText(" Всего было запущенно тестов: " + yesno1 + "\n Из них удачно завершились: " + yes1 + "\n Не удачно завершились: " + no6 + "\n________________________________\n________________________________\n" + reader.a);
                    }
                }
            } catch (Exception var6) {
                JOptionPane.showMessageDialog((Component)null, "Что-то пошло не так...");
            }

        }
    }
}
