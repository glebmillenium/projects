package Graph;

import java.awt.*;
import java.io.IOException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.script.ScriptException;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JRadioButton;
import javax.swing.JTextField;

/**
 *  GraphFrame - графический класс, инициализирует пользовательский интерфейс
 *               путем создания объекта данного класса, через стандартный 
 *               (не расширенный) конструктор GraphFrame.
 * 
 *  @author Ан Глеб
 */
public class GraphFrame extends javax.swing.JFrame {

    /**
     *  Поля класса GraphFrame.
     * 
     *  private int delta   - 
     *  private int width   - ширина графика функции (по умолчанию 520)
     *  private int height  - высота графика функции (по умолчанию 520)
     *  private double step - шаг значения функции в один пиксель 
     *                        (масштаб графика)
     * 
     *  private JPanelGraph PanelGraph - Объект переопределенного графического
     *                                   пользовательского класса 
     *                                   типа PanelGraph
     *  private static java.util.List<JTextField> FieldsFunction - коллекция, 
     *          содержит функции(формулы) вводимые пользователем в TextField-ы
     */
    private int width = 520;
    private int height = 520;
    private int w = 0;
    private int h = 0;
    private double step = 0.05;
    private JPanelGraph PanelGraph = 
            new JPanelGraph(this.width, this.height, this.step);
    private static java.util.List<JTextField> FieldsFunction = 
            new ArrayList<JTextField>();
    private static java.util.List<JButton> ButtonsFunction = 
            new ArrayList<JButton>();
    private static java.util.List<Color> ColorsFunction = new ArrayList<Color>();
    private int delta = 0;
    private ShowColor ColorChoose = new ShowColor();
    
    Color[] button_color_cold = {new Color(180, 121, 100), 
                                 new Color(187, 23, 90),
                                 new Color(197, 43, 92),
                                 new Color(177, 82, 70),
                                 new Color(180, 100, 50),
                                 new Color(180, 41, 31)
                                 };
    
    Color[] button_color_warm = {new Color(180,121,100), 
                                 new Color(0,47,94),
                                 new Color(0,55,80),
                                 new Color(0,75,65),
                                 new Color(0,55,80),
                                 new Color(0,100,55)
                                 };
    /**
     * GraphFrame - конструктор графического класса, который инициализирует и 
     *              визуализирует графические компоненты вызываемого окна.
     * 
     * @param - отсуствуют
     */
    public GraphFrame() {
        initComponents();           //Вызов инициализаторов графических 
        paintGraphPanel(PanelGraph);//компонентов
        addTextField();             //Вывод Текстового поля для ввода функции
        jRadioButton3.setToolTipText("Используется для построения математической модели вида: y = f(x)");
        jRadioButton4.setToolTipText("Применяется для построения и исследования математических моделей зависящей от переменной времени: y = f(t)");
        jRadioButton13.setToolTipText("Построение параметрической функции, зависимость которой выражается через дополнительную величину — параметр: x(t);y(t)");
        jRadioButton12.setToolTipText("Построение в полярной системе координат, в которой каждая точка на плоскости определяется двумя числами — полярным углом и полярным радиусом: φ = r(a)");
    }
    
    /**
     * Метод paintGraphPanel - вырисовывает дополнительные элемент, в котором
     *                         будет вырисовываться график функции
     * 
     * @param Graph 
     * @return void
     */
    public void paintGraphPanel(JPanelGraph Graph) {
            
        javax.swing.GroupLayout jPanelLayout = new javax.swing.GroupLayout(Graph);
        Graph.setLayout(jPanelLayout);
        Graph.setBackground(Color.white);
        jPanelLayout.setHorizontalGroup(
                jPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.CENTER)
                .addGap(0, this.width, Short.MAX_VALUE)
        );
        jPanelLayout.setVerticalGroup(
                jPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.CENTER)
                .addGap(0, this.height, Short.MAX_VALUE)
        );

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                .addGroup(layout.createSequentialGroup()
                        .addGap(320, 320, 320)
                        .addComponent(Graph, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addContainerGap(112, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addGap(30, 30, 30)
                        .addComponent(Graph, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addContainerGap(112, Short.MAX_VALUE))
        );

        pack();
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        buttonGroup1 = new javax.swing.ButtonGroup();
        buttonGroup2 = new javax.swing.ButtonGroup();
        Button = new javax.swing.JButton();
        jButtonHelp = new javax.swing.JButton();
        jButtonFunction = new javax.swing.JButton();
        jButton1 = new javax.swing.JButton();
        text = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        JLabel = new javax.swing.JLabel();
        jRadioButton1 = new javax.swing.JRadioButton();
        jRadioButton2 = new javax.swing.JRadioButton();
        jRadioButton5 = new javax.swing.JRadioButton();
        jRadioButton6 = new javax.swing.JRadioButton();
        jRadioButton7 = new javax.swing.JRadioButton();
        jRadioButton8 = new javax.swing.JRadioButton();
        jRadioButton9 = new javax.swing.JRadioButton();
        jRadioButton10 = new javax.swing.JRadioButton();
        jRadioButton11 = new javax.swing.JRadioButton();
        jLabel1 = new javax.swing.JLabel();
        left = new javax.swing.JButton();
        down = new javax.swing.JButton();
        right = new javax.swing.JButton();
        up = new javax.swing.JButton();
        jLabel2 = new javax.swing.JLabel();
        jCheckBox1 = new javax.swing.JCheckBox();
        jRadioButton3 = new javax.swing.JRadioButton();
        jRadioButton4 = new javax.swing.JRadioButton();
        jRadioButton12 = new javax.swing.JRadioButton();
        jRadioButton13 = new javax.swing.JRadioButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.DO_NOTHING_ON_CLOSE);
        setPreferredSize(new java.awt.Dimension(910, 650));
        addWindowListener(new java.awt.event.WindowAdapter() {
            public void windowClosing(java.awt.event.WindowEvent evt) {
                formWindowClosing(evt);
            }
        });
        addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyPressed(java.awt.event.KeyEvent evt) {
                formKeyPressed(evt);
            }
        });

        Button.setText("Построить!");
        Button.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                ButtonActionPerformed(evt);
            }
        });

        jButtonHelp.setText("F1 Справка");
        jButtonHelp.setCursor(new java.awt.Cursor(java.awt.Cursor.DEFAULT_CURSOR));
        jButtonHelp.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonHelpActionPerformed(evt);
            }
        });

        jButtonFunction.setBackground(java.awt.SystemColor.desktop);
        jButtonFunction.setText("<html>Добавить функцию</html>");
        jButtonFunction.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonFunctionActionPerformed(evt);
            }
        });

        jButton1.setBackground(java.awt.SystemColor.desktop);
        jButton1.setText("<html>Удалить функцию</html>");
        jButton1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton1ActionPerformed(evt);
            }
        });

        text.setHorizontalAlignment(javax.swing.SwingConstants.RIGHT);
        text.setText("y=f(x): ");

        jScrollPane1.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));

        JLabel.setForeground(new java.awt.Color(198, 45, 45));
        JLabel.setBorder(javax.swing.BorderFactory.createEtchedBorder(new java.awt.Color(242, 241, 240), new java.awt.Color(242, 241, 240)));
        JLabel.setCursor(new java.awt.Cursor(java.awt.Cursor.DEFAULT_CURSOR));
        jScrollPane1.setViewportView(JLabel);

        buttonGroup1.add(jRadioButton1);
        jRadioButton1.setText("x2.5");
        jRadioButton1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioButton1ActionPerformed(evt);
            }
        });

        buttonGroup1.add(jRadioButton2);
        jRadioButton2.setText("x2.0");
        jRadioButton2.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioButton2ActionPerformed(evt);
            }
        });

        buttonGroup1.add(jRadioButton5);
        jRadioButton5.setText("x1.5");
        jRadioButton5.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioButton5ActionPerformed(evt);
            }
        });

        buttonGroup1.add(jRadioButton6);
        jRadioButton6.setSelected(true);
        jRadioButton6.setText("x1");
        jRadioButton6.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioButton6ActionPerformed(evt);
            }
        });

        buttonGroup1.add(jRadioButton7);
        jRadioButton7.setText("x0.75");
        jRadioButton7.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioButton7ActionPerformed(evt);
            }
        });

        buttonGroup1.add(jRadioButton8);
        jRadioButton8.setText("x0.5");
        jRadioButton8.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioButton8ActionPerformed(evt);
            }
        });

        buttonGroup1.add(jRadioButton9);
        jRadioButton9.setText("x0.25");
        jRadioButton9.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioButton9ActionPerformed(evt);
            }
        });

        buttonGroup1.add(jRadioButton10);
        jRadioButton10.setText("x0.15");
        jRadioButton10.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioButton10ActionPerformed(evt);
            }
        });

        buttonGroup1.add(jRadioButton11);
        jRadioButton11.setText("x0.1");
        jRadioButton11.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioButton11ActionPerformed(evt);
            }
        });

        jLabel1.setText("Масштаб:");

        left.setText("lft");
        left.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                leftActionPerformed(evt);
            }
        });

        down.setText("Dn");
        down.setPreferredSize(new java.awt.Dimension(50, 30));
        down.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                downActionPerformed(evt);
            }
        });

        right.setText("rgt");
        right.setPreferredSize(new java.awt.Dimension(45, 20));
        right.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                rightActionPerformed(evt);
            }
        });

        up.setText("Up");
        up.setPreferredSize(new java.awt.Dimension(45, 20));
        up.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                upActionPerformed(evt);
            }
        });

        jLabel2.setText("Сдвинуть оси:");

        jCheckBox1.setText("<html>Обозначить десятичные деления</html>");
        jCheckBox1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jCheckBox1ActionPerformed(evt);
            }
        });

        buttonGroup2.add(jRadioButton3);
        jRadioButton3.setSelected(true);
        jRadioButton3.setText("f(x)");
        jRadioButton3.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioButton3ActionPerformed(evt);
            }
        });

        buttonGroup2.add(jRadioButton4);
        jRadioButton4.setText("f(t)");
        jRadioButton4.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioButton4ActionPerformed(evt);
            }
        });

        buttonGroup2.add(jRadioButton12);
        jRadioButton12.setText("<html>r(a)</html>");
        jRadioButton12.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioButton12ActionPerformed(evt);
            }
        });

        buttonGroup2.add(jRadioButton13);
        jRadioButton13.setText("y(t) ;x(t)");
        jRadioButton13.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioButton13ActionPerformed(evt);
            }
        });

        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(layout.createSequentialGroup()
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING)
                    .add(org.jdesktop.layout.GroupLayout.LEADING, layout.createSequentialGroup()
                        .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(text, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 56, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                            .add(layout.createSequentialGroup()
                                .addContainerGap()
                                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                                    .add(jRadioButton3)
                                    .add(jRadioButton4)
                                    .add(jRadioButton13)
                                    .add(jRadioButton12, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))))
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(layout.createSequentialGroup()
                                .add(jScrollPane1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 203, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED, 712, Short.MAX_VALUE)
                                .add(jButtonHelp))
                            .add(layout.createSequentialGroup()
                                .add(jButtonFunction, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 98, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                                .add(jButton1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 95, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                                .add(0, 0, Short.MAX_VALUE))))
                    .add(org.jdesktop.layout.GroupLayout.LEADING, layout.createSequentialGroup()
                        .addContainerGap()
                        .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(jLabel1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 87, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                            .add(layout.createSequentialGroup()
                                .add(26, 26, 26)
                                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                                    .add(jRadioButton9)
                                    .add(jRadioButton8)
                                    .add(jRadioButton10)
                                    .add(jRadioButton11)
                                    .add(layout.createSequentialGroup()
                                        .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                                            .add(jRadioButton2)
                                            .add(jRadioButton7)
                                            .add(jRadioButton5)
                                            .add(jRadioButton6)
                                            .add(jRadioButton1))
                                        .add(18, 18, 18)
                                        .add(jCheckBox1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 155, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)))))))
                .addContainerGap())
            .add(layout.createSequentialGroup()
                .add(25, 25, 25)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jLabel2)
                    .add(layout.createSequentialGroup()
                        .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING)
                            .add(layout.createSequentialGroup()
                                .add(51, 51, 51)
                                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING)
                                    .add(down, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 50, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                                    .add(up, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 50, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)))
                            .add(org.jdesktop.layout.GroupLayout.LEADING, left, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 50, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                        .add(right, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 50, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                    .add(Button, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 124, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(layout.createSequentialGroup()
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(layout.createSequentialGroup()
                        .addContainerGap()
                        .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(jScrollPane1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 116, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                            .add(layout.createSequentialGroup()
                                .add(text)
                                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                                .add(jRadioButton3)
                                .add(0, 0, 0)
                                .add(jRadioButton4)
                                .add(0, 0, 0)
                                .add(jRadioButton13)
                                .add(0, 0, 0)
                                .add(jRadioButton12, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED))))
                    .add(jButtonHelp))
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jButton1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 48, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(org.jdesktop.layout.GroupLayout.TRAILING, jButtonFunction, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 48, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(jLabel1)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(layout.createSequentialGroup()
                        .add(jRadioButton1)
                        .add(0, 0, 0)
                        .add(jRadioButton2)
                        .add(0, 0, 0)
                        .add(jRadioButton5)
                        .add(0, 0, 0)
                        .add(jRadioButton6))
                    .add(jCheckBox1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 86, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .add(0, 0, 0)
                .add(jRadioButton7)
                .add(0, 0, 0)
                .add(jRadioButton8)
                .add(0, 0, 0)
                .add(jRadioButton9)
                .add(0, 0, 0)
                .add(jRadioButton10)
                .add(0, 0, 0)
                .add(jRadioButton11)
                .add(18, 18, 18)
                .add(jLabel2)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(up, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 30, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .add(1, 1, 1)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(right, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 30, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(left, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 30, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .add(1, 1, 1)
                .add(down, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 30, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(Button, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 40, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(24, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents


    private void formWindowClosing(java.awt.event.WindowEvent evt) {//GEN-FIRST:event_formWindowClosing
        AGV.windowClose(evt);
    }//GEN-LAST:event_formWindowClosing

    private void ButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_ButtonActionPerformed
        buildGraph();
    }//GEN-LAST:event_ButtonActionPerformed

    private void buildGraph()
    {
        String[] expression = new String[FieldsFunction.size()];
        String[] sub_expression = {"0"};
        Color[] colors = new Color[ButtonsFunction.size()];
        int check_correct_expression = 0;
        for(int i=0;i < FieldsFunction.size();i++)
        {
            expression[i] = FieldsFunction.get(i).getText().replaceAll(" ", "");
            colors[i] = ButtonsFunction.get(i).getBackground();
            if (expression[i].isEmpty()) 
                check_correct_expression = 1;
        }
        try {
            
            if (check_correct_expression == 1)
                PanelGraph.treatmentExpression(sub_expression, colors, this.step, this.w, this.h);
            else
                PanelGraph.treatmentExpression(expression, colors, this.step, this.w, this.h);
            
            PanelGraph.drawGraph();

        } catch (ScriptException ex) {
            Logger.getLogger(GraphFrame.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(GraphFrame.class.getName()).log(Level.SEVERE, null, ex);
        }

    }
    
    private void jButtonHelpActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonHelpActionPerformed
        java.awt.EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                try {
                    new HelpFrame().setVisible(true);
                } catch (IOException ex) {
                    Logger.getLogger(GraphFrame.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
        });
    }//GEN-LAST:event_jButtonHelpActionPerformed

    private void jButtonFunctionActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonFunctionActionPerformed
        addTextField();
    }//GEN-LAST:event_jButtonFunctionActionPerformed

    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton1ActionPerformed
        if(FieldsFunction.size() > 1) {
            int index = FieldsFunction.size() - 1;
            JTextField field = FieldsFunction.remove(index);
            JButton button = ButtonsFunction.remove(index);
            JLabel.remove(field);
            JLabel.remove(button);
            this.delta-=25;
            JLabel.setPreferredSize(new Dimension(172,this.delta));
            JLabel.repaint();
            JLabel.revalidate();                   
        }  
    }//GEN-LAST:event_jButton1ActionPerformed

    private void jRadioButton1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioButton1ActionPerformed
        this.step = 0.125;
        buildGraph();
    }//GEN-LAST:event_jRadioButton1ActionPerformed

    private void jRadioButton2ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioButton2ActionPerformed
        this.step = 0.1;
        buildGraph();
    }//GEN-LAST:event_jRadioButton2ActionPerformed

    private void jRadioButton5ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioButton5ActionPerformed
        this.step = 0.075;
        buildGraph();
    }//GEN-LAST:event_jRadioButton5ActionPerformed

    private void jRadioButton6ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioButton6ActionPerformed
        this.step = 0.05;
        buildGraph();
    }//GEN-LAST:event_jRadioButton6ActionPerformed

    private void jRadioButton7ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioButton7ActionPerformed
        this.step = 0.0375;
        buildGraph();
    }//GEN-LAST:event_jRadioButton7ActionPerformed

    private void jRadioButton8ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioButton8ActionPerformed
        this.step = 0.025;
        buildGraph();
    }//GEN-LAST:event_jRadioButton8ActionPerformed

    private void jRadioButton9ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioButton9ActionPerformed
        this.step = 0.0125;
        buildGraph();
    }//GEN-LAST:event_jRadioButton9ActionPerformed

    private void jRadioButton10ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioButton10ActionPerformed
        this.step = 0.05*0.15;
        buildGraph();
    }//GEN-LAST:event_jRadioButton10ActionPerformed

    private void jRadioButton11ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioButton11ActionPerformed
        this.step = 0.005;
        buildGraph();
    }//GEN-LAST:event_jRadioButton11ActionPerformed

    private void rightActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_rightActionPerformed
        this.w += 2/step;
        buildGraph();
        colorButton_w();
    }//GEN-LAST:event_rightActionPerformed

    private void upActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_upActionPerformed
        this.h -= 2/step;
        buildGraph();
        colorButton_h();
    }//GEN-LAST:event_upActionPerformed

    private void downActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_downActionPerformed
        this.h += 2/step;
        buildGraph();
        colorButton_h();
    }//GEN-LAST:event_downActionPerformed

    private void leftActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_leftActionPerformed
        this.w -= 2/step;
        buildGraph();
        colorButton_w();
    }//GEN-LAST:event_leftActionPerformed

    private void formKeyPressed(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_formKeyPressed
        
    }//GEN-LAST:event_formKeyPressed

    private void jCheckBox1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jCheckBox1ActionPerformed
        if (jCheckBox1.isSelected())
            PanelGraph.drawDecimalDivision(1);
        else 
            PanelGraph.drawDecimalDivision(0);
    }//GEN-LAST:event_jCheckBox1ActionPerformed

    private void jRadioButton4ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioButton4ActionPerformed
        PanelGraph.changedTypeFunction(2);
        text.setText("y=f(t):");
    }//GEN-LAST:event_jRadioButton4ActionPerformed

    private void jRadioButton3ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioButton3ActionPerformed
        PanelGraph.changedTypeFunction(1);
        text.setText("y=f(x):");
    }//GEN-LAST:event_jRadioButton3ActionPerformed

    private void jRadioButton12ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioButton12ActionPerformed
        PanelGraph.changedTypeFunction(4);
        text.setText("r=f(a):");
    }//GEN-LAST:event_jRadioButton12ActionPerformed

    private void jRadioButton13ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioButton13ActionPerformed
        PanelGraph.changedTypeFunction(3);
        text.setText("y(t)=x(t):");
    }//GEN-LAST:event_jRadioButton13ActionPerformed

    private void colorButton_w()
    {
        int k = (int) ( this.w / (2/step) );
        if (k >= 0)
        {
            left.setBackground(button_color_warm[k]);
            right.setBackground(button_color_cold[k]);
        }
        else
        {
            right.setBackground(button_color_warm[Math.abs(k)]);
            left.setBackground(button_color_cold[Math.abs(k)]);
        }
    }
    
    private void colorButton_h()
    {
        int k = (int) ( this.h / (2/step) );
        if (k >= 0)
        {
            down.setBackground(button_color_warm[k]);
            up.setBackground(button_color_cold[k]);
        }
        else
        {
            down.setBackground(button_color_warm[Math.abs(k)]);
            up.setBackground(button_color_cold[Math.abs(k)]);
        }
    }
    
    private void addTextField(){
        JTextField field = new JTextField(" ");
        final JButton button = new JButton("...");
        ButtonsFunction.add(button);
        FieldsFunction.add(field);
        field.setAlignmentX(JButton.CENTER_ALIGNMENT);
        //field.setFont(font);
        field.setSize(150, 30);
        button.setSize(30, 30);
        button.setBackground(Color.black);
        button.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                button.setBackground(ColorChoose.choose());
            }
        });
 
        field.setLocation(0, delta);
        button.setLocation(150, delta);
        this.delta+=25;
        JLabel.add(field);
        JLabel.add(button);
        JLabel.setPreferredSize(new Dimension(172, this.delta));
        JLabel.repaint();
        JLabel.revalidate();
    }
    
    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(GraphFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(GraphFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(GraphFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(GraphFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new GraphFrame().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton Button;
    private javax.swing.JLabel JLabel;
    private javax.swing.ButtonGroup buttonGroup1;
    private javax.swing.ButtonGroup buttonGroup2;
    private javax.swing.JButton down;
    private javax.swing.JButton jButton1;
    private javax.swing.JButton jButtonFunction;
    private javax.swing.JButton jButtonHelp;
    private javax.swing.JCheckBox jCheckBox1;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JRadioButton jRadioButton1;
    private javax.swing.JRadioButton jRadioButton10;
    private javax.swing.JRadioButton jRadioButton11;
    private javax.swing.JRadioButton jRadioButton12;
    private javax.swing.JRadioButton jRadioButton13;
    private javax.swing.JRadioButton jRadioButton2;
    private javax.swing.JRadioButton jRadioButton3;
    private javax.swing.JRadioButton jRadioButton4;
    private javax.swing.JRadioButton jRadioButton5;
    private javax.swing.JRadioButton jRadioButton6;
    private javax.swing.JRadioButton jRadioButton7;
    private javax.swing.JRadioButton jRadioButton8;
    private javax.swing.JRadioButton jRadioButton9;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JButton left;
    private javax.swing.JButton right;
    private javax.swing.JLabel text;
    private javax.swing.JButton up;
    // End of variables declaration//GEN-END:variables

}
