/*
 * Создано в SharpDevelop.
 * Пользователь: Глеб
 * Дата: 29.01.2016
 * Время: 5:30
 * 
 * 
 */
using System;
using System.Drawing;

namespace graphs
{
    /// <summary>
    /// Класс Node - предназначен для хранения и
    /// реализации графического состояния узлов 
    /// и соединяющих элементов в графе
    /// </summary>
    public class Node
    {
        public readonly int id;
        private readonly Graphics __obj;
        public readonly Snippet x;
        public readonly Snippet y;
        public Snippet centr;
        public string name;
        public Color color;
    	
		public Node(int id, Graphics obj, int x0, int y0, string name)
		{
			this.x = new Snippet() { first = x0, second = x0};
			this.y = new Snippet() { first = y0, second = y0};
			this.centr = new Snippet() { first = x0, second = y0};
			this.__obj = obj;
			this.name = name;
			this.id = id;
		}
		
		public Node(int id, Graphics obj, int x0, int x1, int y0, int y1, string name)
		{
			this.id = id;
			
			this.x = new Snippet() {
				first = x0,
				second = x1
			};
			
			this.y = new Snippet() {
				first = y0,
				second = y1
			};
			
			this.centr = new Snippet() { 
				first = ((x0+x1)/2), 
				second = ((y0+y1)/2)
			};
			
			this.__obj = obj;
			this.name = name;
		}
		public bool belongToNode(int x, int y)
		{
			return ((x >= this.x.first) 
			        && (x <= this.x.second) 
			        && (y >= this.y.first) 
			        && (y <= this.y.second));
		}
		public int getIdOnCoordinate(int x, int y)
		{
			return belongToNode(x, y) ? this.id : -1;
		}
	}
}
