package br.com.mario_junior.games;

import java.awt.Graphics;

import javax.swing.JFrame;
import javax.swing.JPanel;

public class Janela extends JFrame{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private JPanel tela;

	public Janela() {
		tela = new JPanel() {
			/**
			 * 
			 */
			private static final long serialVersionUID = 1L;

			@Override
			protected void paintComponent(Graphics g) {
				// A pintura ocorre aqui
			}
		};
		
		super.getContentPane().add(tela);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		setSize(640, 480);
		setVisible(true);
	}
	
	public static void main(String[] args) {
		new Janela();
	}
}
