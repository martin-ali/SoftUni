<?php

namespace PhpBlogBundle\Controller;

use PhpBlogBundle\Entity\Article;
use PhpBlogBundle\Form\ArticleType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class ArticleController extends Controller
{
	/**
	 * @Route("/article/create", name="article_create")
	 * @Security("is_granted('IS_AUTHENTICATED_FULLY')")
	 * @param Request $request
	 * @return \Symfony\Component\HttpFoundation\Response
	 */
	public function create(Request $request)
	{
		$article = new Article();

		$form = $this->createForm(ArticleType::class, $article);
		$form->handleRequest($request);

		if ($form->isSubmitted() && $form->isValid())
		{
			$article->setAuthor($this->getUser());

			$entityManager = $this->getDoctrine()->getManager();
			$entityManager->persist($article);
			$entityManager->flush();

			return $this->redirectToRoute("blog_index");
		}

		return $this->render("article/create.html.twig",
			["form" => $form->createView()]);
	}

	/**
	 * @Route("/article/{id}", name="article_details")
	 * @param $id
	 * @return \Symfony\Component\HttpFoundation\Response
	 */
	public function details($id)
	{
		$article = $this
			->getDoctrine()
			->getRepository(Article::class)
			->find($id);

		return $this->render("article/details.html.twig",
			["article" => $article]);
	}

	/**
	 * @Route("/article/edit/{id}", name="article_edit")
	 * @param Request $request
	 * @param $id
	 * @return \Symfony\Component\HttpFoundation\Response
	 */
	public function edit(Request $request, $id)
	{
		$userId = $this->getUser()->getId();
		$article = $this
			->getDoctrine()
			->getRepository(Article::class)
			->find($id);

		$form = $this->createForm(ArticleType::class, $article);
		$form->handleRequest($request);

		$userIsAuthor = ($article->getAuthorId() === $userId);
		if ($form->isSubmitted() && $form->isValid() && $userIsAuthor)
		{
			$entityManager = $this->getDoctrine()->getManager();
			$entityManager->merge($article);
			$entityManager->flush();

			return $this->redirectToRoute("blog_index");
		}

		return $this->render("article/edit.html.twig",
			[
				"article" => $article,
				"form" => $form->createView()
			]);
	}

	/**
	 * @Route("/article/delete/{id}", name="article_delete")
	 * @param Request $request
	 * @param $id
	 * @return \Symfony\Component\HttpFoundation\Response
	 */
	public function delete(Request $request, $id)
	{
		$userId = $this->getUser()->getId();
		$article = $this
			->getDoctrine()
			->getRepository(Article::class)
			->find($id);

		$form = $this->createForm(ArticleType::class, $article);
		$form->handleRequest($request);

		$userIsAuthor = ($article->getAuthorId() === $userId);
		if ($form->isSubmitted() && $form->isValid() && $userIsAuthor)
		{
			$entityManager = $this->getDoctrine()->getManager();
			$entityManager->remove($article);
			$entityManager->flush();

			return $this->redirectToRoute("blog_index");
		}

		return $this->render("article/delete.html.twig",
			[
				"article" => $article,
				"form" => $form->createView()
			]);
	}
}
