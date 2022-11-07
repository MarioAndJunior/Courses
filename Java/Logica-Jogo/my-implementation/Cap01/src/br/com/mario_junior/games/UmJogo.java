package br.com.mario_junior.games;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

import javax.swing.JFrame;
import javax.swing.JPanel;

public class UmJogo extends JFrame{

	private static final long serialVersionUID = 1L;
	private final int FPS = 1000 / 20; // 50
	private JPanel tela;
	private boolean jogando = true;
	private boolean fimDeJogo = false;
	
	private Elemento tiro;
	private Elemento jogador;
	private Elemento [] blocos;
	
	private int pontos;
	private int larg = 50;
	private int linhaLimite = 350;
	private java.util.Random r = new java.util.Random();
	private boolean[] controleTecla = new boolean[4];
	
	class Elemento{
		public int x;
		public int y;
		public int altura;
		public int largura;
		public float velocidade;
		
		public Elemento(int x, int y, int altura, int largura) {
			this.x = x;
			this.y = y;
			this.altura = altura;
			this.largura = largura;
		}
	}
	
	public UmJogo() {
		this.addKeyListener(new KeyListener() {
			
			@Override
			// Evento para a tecla apertada
			public void keyTyped(KeyEvent e) {
			}

			@Override
			// Evento para a tecla liberada
			public void keyPressed(KeyEvent e) {	
				setaTecla(e.getKeyCode(), true);
			}

			@Override
			// Evento para a tecla pressionada
			public void keyReleased(KeyEvent e) {
				setaTecla(e.getKeyCode(), false);
			}
		});
		
		tiro = new Elemento(0, 0, 1, 0);
		jogador = new Elemento(0, 0, larg, larg);
		jogador.velocidade = 5;
		
		blocos = new Elemento[5];
		for (int i = 0; i < blocos.length; i++) {
			int espaco = i * larg + 10 * (i + 1);
			blocos[i] = new Elemento(espaco, 0, larg, larg);
			blocos[i].velocidade = 1;
		}
		
		tela = new JPanel() {
			private static final long serialVersionUID = 1L;
			
			@Override
			public void paintComponent(Graphics g) {
				g.setColor(Color.WHITE);
				g.fillRect(0, 0, tela.getWidth(), tela.getHeight());
				
				g.setColor(Color.RED);
				g.fillRect(tiro.x, tiro.y, tiro.largura, tela.getHeight());
				
				g.setColor(Color.GREEN);
				g.fillRect(jogador.x, jogador.y, jogador.largura, jogador.altura);
				
				g.setColor(Color.BLUE);
				for (Elemento bloco : blocos) {
					g.fillRect(bloco.x, bloco.y, bloco.largura, bloco.altura);
				}
				
				g.setColor(Color.GRAY);
				g.drawLine(0, linhaLimite, tela.getWidth(), linhaLimite);
				
				g.drawString("Pontos " + pontos, 0, 10);
			}
		};
		
		getContentPane().add(tela);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(640, 480);
		setVisible(true);
		setResizable(false);
		
		jogador.x = tela.getWidth() / 2 - jogador.x / 2;
		jogador.y = tela.getHeight() - jogador.altura;
		tiro.altura = tela.getHeight() - jogador.altura;
		tiro.largura = 1;
		
	}
	
	public void inicia() {
		long prxAtualizacao = 0;
		while(jogando) {
			if (System.currentTimeMillis() >= prxAtualizacao) {
				atualizaJogo();
				tela.repaint();
				prxAtualizacao = System.currentTimeMillis() + FPS;			
				}
		}
	}
	
	private void atualizaJogo() {
		if (fimDeJogo)
			return;
		
		if (controleTecla[2])
			jogador.x -= jogador.velocidade;
		else if(controleTecla[3])
			jogador.x += jogador.velocidade;
		
		if (jogador.x < 0)
			jogador.x = tela.getWidth() - jogador.largura;
		
		if (jogador.x + jogador.largura > tela.getWidth())
			jogador.x = 0;
		
		tiro.y = 0;
		tiro.x = jogador.x + jogador.largura / 2;
		
		for (Elemento bloco : blocos) {
			if (bloco.y > linhaLimite) {
				fimDeJogo = true;
				break;
			}
			
			if (colide(bloco, tiro) && bloco.y > 0) {
				bloco.y -= bloco.velocidade * 2;
				tiro.y = bloco.y;
			} else {
				int sorte = r.nextInt(10);
				if(sorte == 0)
					bloco.y += bloco.velocidade + 1;
				else if(sorte == 5)
					bloco.y -= bloco.velocidade;
				else
					bloco.y += bloco.velocidade;
			}
		}
	}
	
	private boolean colide(Elemento a, Elemento b) {
		if (a.x + a.largura >= b.x && a.x < b.x + b.largura) {
			return true;
		}
		
		return false;
	}
	
	private void setaTecla(int tecla, boolean pressionada) {
		switch (tecla) {
			case KeyEvent.VK_ESCAPE: {
				// ESC
				jogando = false;
				dispose();
				break;
			}
			case KeyEvent.VK_UP: {
				// Seta para cima
				controleTecla[0] = pressionada;
				break;
			}
			case KeyEvent.VK_DOWN: {
				// Seta para baixo
				controleTecla[1] = pressionada;
				break;
			}
			case KeyEvent.VK_LEFT: {
				// Seta para esquerda
				controleTecla[2] = pressionada;
				break;
			}
			case KeyEvent.VK_RIGHT: {
				// Seta para direita
				controleTecla[3] = pressionada;
				break;
			}
		}
	}
	
	public static void main(String[] args) {
		UmJogo jogo = new UmJogo();
		jogo.inicia();
	}
	
}
