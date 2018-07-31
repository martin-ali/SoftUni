<?php

namespace PhpBlogBundle\Controller;

use PhpBlogBundle\Entity\Article;
use PhpBlogBundle\Entity\Comment;
use PhpBlogBundle\Form\CommentType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Bridge\Doctrine\Tests\Fixtures\User;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class CommentController extends Controller
{
	/**
	 * @Route("/comment/create/{articleId}", name="comment_create")
	 * @Security("is_granted('IS_AUTHENTICATED_FULLY')")
	 * @param Request $request
	 * @param $articleId
	 * @return \Symfony\Component\HttpFoundation\Response
	 */
	public function create(Request $request, $articleId)
	{
		$comment = new Comment();

		$form = $this->createForm(CommentType::class, $comment);
		$form->handleRequest($request);

		if ($form->isSubmitted() && $form->isValid())
		{
			// Automatically maps authorId
			$comment->setAuthor($this->getUser());

			$article = $this
				->getDoctrine()
				->getRepository(Article::class)
				->find($articleId);
			$article->addComment($comment);
			$comment->setArticle($article);

			$entityManager = $this->getDoctrine()->getManager();
			$entityManager->persist($comment);
			$entityManager->persist($article);
			$entityManager->flush();

			return $this->redirectToRoute("article_details", ["id" => $articleId]);
		}

		return $this->render("comment/create.html.twig",
			[
				"articleId" => $articleId,
				"form" => $form->createView()
			]);
	}

	/**
	 * @Route("/comment/details/{id}", name="comment_details")
	 * @param $id
	 * @return \Symfony\Component\HttpFoundation\Response
	 */
	public function details($id)
	{
		$comment = $this
			->getDoctrine()
			->getRepository(Comment::class)
			->find($id);

		$userIsAuthor = $this->getUser()
			&& $this->getUser()->getId() === $comment->getAuthorId();

		return $this->render("comment/details.html.twig",
			[
				"userIsAuthor" => $userIsAuthor,
				"articleId" => $comment->getId(),
				"comment" => $comment
			]);
	}

	/**
	 * @Route("/comment/edit/{id}", name="comment_edit")
	 * @Security("is_granted('IS_AUTHENTICATED_FULLY')")
	 * @param Request $request
	 * @param $id
	 * @return \Symfony\Component\HttpFoundation\Response
	 */
	public function edit(Request $request, $id)
	{
		$userId = $this->getUser()->getId();
		$comment = $this
			->getDoctrine()
			->getRepository(Comment::class)
			->find($id);

		$form = $this->createForm(CommentType::class, $comment);
		$form->handleRequest($request);

		$userIsAuthor = ($comment->getAuthorId() === $userId);
		if ($form->isSubmitted() && $form->isValid() && $userIsAuthor)
		{
			$entityManager = $this->getDoctrine()->getManager();
			$entityManager->merge($comment);
			$entityManager->flush();

			return $this->redirectToRoute("comment_details", ["id" => $id]);
		}

		return $this->render("comment/edit.html.twig",
			[
				"comment" => $comment,
				"form" => $form->createView()
			]);
	}

	/**
	 * @Route("/comment/delete/{id}", name="comment_delete")
	 * @Security("is_granted('IS_AUTHENTICATED_FULLY')")
	 * @param Request $request
	 * @param $id
	 * @return \Symfony\Component\HttpFoundation\Response
	 */
	public function delete(Request $request, $id)
	{
		$userId = $this->getUser()->getId();
		$comment = $this
			->getDoctrine()
			->getRepository(Comment::class)
			->find($id);

		$form = $this->createForm(CommentType::class, $comment);
		$form->handleRequest($request);

		$userIsAuthor = ($comment->getAuthorId() === $userId);
		if ($form->isSubmitted() && $form->isValid() && $userIsAuthor)
		{
			$entityManager = $this->getDoctrine()->getManager();
			$entityManager->remove($comment);
			$entityManager->flush();

			return $this->redirectToRoute("blog_index");
		}

		return $this->render("comment/delete.html.twig",
			[
				"comment" => $comment,
				"form" => $form->createView()
			]);
	}
}
