<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Project;
use AppBundle\Form\ProjectType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class ProjectController extends Controller
{
	/**
	 * @Route("/", name="homepage")
	 */
	public function index(Request $request)
	{
		$projects = $this
			->getDoctrine()
			->getRepository(Project::class)
			->findAll();

		return $this->render("project/index.html.twig", ["projects" => $projects]);
	}

	/**
	 * @Route("/create", name="create")
	 */
	public function create(Request $request)
	{
		$project = new Project();

		$form = $this->createForm(ProjectType::class, $project);
		$form->handleRequest($request);

		if ($form->isSubmitted() && $form->isValid())
		{
			$entityManager = $this->getDoctrine()->getManager();
			$entityManager->persist($project);
			$entityManager->flush();

			return $this->redirectToRoute("homepage");
		}

		return $this->render("project/create.html.twig",
			[
				"project" => $project,
				"form" => $form->createView()
			]);
	}

	/**
	 * @Route("/edit/{id}", name="edit")
	 */

	public function edit($id, Request $request)
	{
		$project = $this
			->getDoctrine()
			->getRepository(Project::class)
			->find($id);

		$form = $this->createForm(ProjectType::class, $project);
		$form->handleRequest($request);

		if ($form->isSubmitted() && $form->isValid())
		{
			$entityManager = $this->getDoctrine()->getManager();
			$entityManager->persist($project);
			$entityManager->flush();

			return $this->redirectToRoute("homepage");
		}

		return $this->render("project/edit.html.twig",
			[
				"project" => $project,
				"form" => $form->createView()
			]);
	}

	/**
	 * @Route("/delete/{id}", name="delete")
	 * @param $id
	 * @param Request $request
	 * @return \Symfony\Component\HttpFoundation\RedirectResponse|\Symfony\Component\HttpFoundation\Response
	 */
	public function delete($id, Request $request)
	{
		$project = $this
			->getDoctrine()
			->getRepository(Project::class)
			->find($id);

		$form = $this->createForm(ProjectType::class, $project);
		$form->handleRequest($request);

		if ($form->isSubmitted() && $form->isValid())
		{
			$entityManager = $this->getDoctrine()->getManager();
			$entityManager->remove($project);
			$entityManager->flush();

			return $this->redirectToRoute("homepage");
		}

		return $this->render("project/delete.html.twig",
			[
				"project" => $project,
				"form" => $form->createView()
			]);
	}
}
