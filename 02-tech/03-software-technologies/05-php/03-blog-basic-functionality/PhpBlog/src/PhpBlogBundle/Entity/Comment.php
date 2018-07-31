<?php

namespace PhpBlogBundle\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * Comment
 *
 * @ORM\Table(name="comments")
 * @ORM\Entity(repositoryClass="PhpBlogBundle\Repository\CommentRepository")
 */
class Comment
{
	public function __construct()
	{
		$this->dateAdded = new \DateTime('now');
	}

	/**
	 * @var int
	 *
	 * @ORM\Column(name="id", type="integer")
	 * @ORM\Id
	 * @ORM\GeneratedValue(strategy="AUTO")
	 */
	private $id;

	/**
	 * @var string
	 *
	 * @ORM\Column(name="content", type="text")
	 */
	private $content;

	/**
	 * @var \DateTime
	 *
	 * @ORM\Column(name="dateAdded", type="datetime")
	 */
	private $dateAdded;

	/**
	 * @var int
	 *
	 * @ORM\Column(name="articleId", type="integer")
	 */
	private $articleId;

	/**
	 * @var int
	 *
	 * @ORM\Column(name="authorId", type="integer")
	 */
	private $authorId;

	/**
	 * @var Article
	 *
	 * @ORM\ManyToOne(targetEntity="PhpBlogBundle\Entity\Article", inversedBy="comments")
	 * @ORM\JoinColumn(name="articleId", referencedColumnName="id")
	 */
	private $article;

	/**
	 * @var User
	 *
	 * @ORM\ManyToOne(targetEntity="PhpBlogBundle\Entity\User", inversedBy="comments")
	 * @ORM\JoinColumn(name="authorId", referencedColumnName="id")
	 */
	private $author;

	/**
	 * Get id
	 *
	 * @return int
	 */
	public function getId()
	{
		return $this->id;
	}

	/**
	 * Get content
	 *
	 * @return string
	 */
	public function getContent()
	{
		return $this->content;
	}

	/**
	 * Set content
	 *
	 * @param string $content
	 *
	 * @return Comment
	 */
	public function setContent($content)
	{
		$this->content = $content;

		return $this;
	}

	/**
	 * Get dateAdded
	 *
	 * @return \DateTime
	 */
	public function getDateAdded()
	{
		return $this->dateAdded;
	}

	/**
	 * Set dateAdded
	 *
	 * @param \DateTime $dateAdded
	 *
	 * @return Comment
	 */
	public function setDateAdded($dateAdded)
	{
		$this->dateAdded = $dateAdded;

		return $this;
	}

	/**
	 * @return integer
	 */
	public function getArticleId()
	{
		return $this->articleId;
	}

	/**
	 * @param integer $articleId
	 *
	 * @return Comment
	 */
	public function setArticleId($articleId)
	{
		$this->articleId = $articleId;

		return $this;
	}

	/**
	 * @return int
	 */
	public function getAuthorId()
	{
		return $this->authorId;
	}

	/**
	 * @param int $authorId
	 *
	 * @return Comment
	 */
	public function setAuthorId($authorId)
	{
		$this->authorId = $authorId;

		return $this;
	}

	/**
	 * @return Article
	 */
	public function getArticle()
	{
		return $this->article;
	}

	/**
	 * @param Article $article
	 *
	 * @return Comment
	 */
	public function setArticle($article)
	{
		$this->article = $article;

		return $this;
	}

	/**
	 * @return User
	 */
	public function getAuthor()
	{
		return $this->author;
	}

	/**
	 * @param User $author
	 *
	 * @return Comment
	 */
	public function setAuthor($author)
	{
		$this->author = $author;

		return $this;
	}
}

