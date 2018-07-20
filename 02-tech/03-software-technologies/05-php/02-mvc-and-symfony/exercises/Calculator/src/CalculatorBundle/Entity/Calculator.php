<?php

namespace CalculatorBundle\Entity;

use CalculatorBundle\Form\CalculatorType;
use Doctrine\ORM\Query\Expr\Math;

class Calculator
{
	public function __construct()
	{
	}

	/**
	 * @var float
	 */
	private $leftOperand;

	/**
	 * @var float
	 */
	private $rightOperand;

	/**
	 * @var string
	 */
	private $operator;

	/**
	 * @return float
	 */
	public function getLeftOperand()
	{
		return $this->leftOperand;
	}

	/**
	 * @param float $leftOperand
	 * @return Calculator
	 */
	public function setLeftOperand($leftOperand)
	{
		$this->leftOperand = $leftOperand;

		return $this;
	}

	/**
	 * @return float
	 */
	public function getRightOperand()
	{
		return $this->rightOperand;
	}

	/**
	 * @param float $rightOperand
	 * @return Calculator
	 */
	public function setRightOperand($rightOperand)
	{
		$this->rightOperand = $rightOperand;

		return $this;
	}

	/**
	 * @return string
	 */
	public function getOperator()
	{
		return $this->operator;
	}

	/**
	 * @param string $operator
	 * @return Calculator
	 */
	public function setOperator($operator)
	{
		$this->operator = $operator;

		return $this;
	}

	/**
	 * @return float
	 */
	public function calculate()
	{
		$result = 0;

		switch ($this->operator)
		{
			case '+':
				$result = $this->leftOperand + $this->rightOperand;
				break;
			case '-':
				$result = $this->leftOperand - $this->rightOperand;
				break;
			case '*':
				$result = $this->leftOperand * $this->rightOperand;
				break;
			case '/':
				$result = $this->leftOperand / $this->rightOperand;
				break;
			case 'pow':
				$result = $this->leftOperand ** $this->rightOperand;
				break;
			case '^':
				$result = $this->leftOperand ^ $this->rightOperand;
				break;
			case '|':
				$result = $this->leftOperand | $this->rightOperand;
				break;
			case '&':
				$result = $this->leftOperand & $this->rightOperand;
				break;
		}

		return $result;
	}
}