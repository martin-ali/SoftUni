<?php

namespace PhpBlogBundle\Controller;

use PhpBlogBundle\Entity\User;
use PhpBlogBundle\Form\UserType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class UserController extends Controller
{
	/**
	 * @Route("register", name="user_register")
	 * @param Request $request
	 * @return \Symfony\Component\HttpFoundation\Response
	 */
	public function register(Request $request)
	{
		$user = new User();

		$form = $this->createForm(UserType::class, $user);
		$form->handleRequest($request);

		if ($form->isSubmitted())
		{
			$password = $this
				->get("security.password_encoder")
				->encodePassword($user, $user->getPassword());

			$user->setPassword($password);

			$entityManager = $this->getDoctrine()->getManager();
			$entityManager->persist($user);
			$entityManager->flush();

			return $this->redirectToRoute("security_login");
		}

		return $this->render("user/register.html.twig",
			["form" => $form->createView()]);
	}

	/**
	 * @Route("/profile", name="user_profile")
	 * @Security("is_granted('IS_AUTHENTICATED_FULLY')")
	 * @return \Symfony\Component\HttpFoundation\Response
	 */
	public function profile()
	{
		$user = $this->getUser();

		return $this->render("user/details.html.twig",
			["user" => $user]);
	}
}