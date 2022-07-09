package br.com.alura.forum.controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HelloControler 
{
	@RequestMapping("/")
	public String hello()
	{
		String hello = "Hello, world!";
		return hello;
	}
}
