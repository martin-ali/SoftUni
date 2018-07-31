<?php

namespace PhpBlogBundle\Controller;

use PhpBlogBundle\Entity\Article;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class HomeController extends Controller
{
	/**
	 * @Route("/", name="blog_index")
	 * @param Request $request
	 * @return \Symfony\Component\HttpFoundation\Response
	 */
	public function indexAction(Request $request)
	{
		$articles = $this->getDoctrine()->getRepository(Article::class)->findAll();
		return $this->render("blog/index.html.twig",
			["articles" => $articles]);
	}
}
