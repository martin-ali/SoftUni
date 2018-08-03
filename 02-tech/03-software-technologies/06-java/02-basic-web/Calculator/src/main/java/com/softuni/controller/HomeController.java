package com.softuni.controller;

import com.softuni.entity.Calculator;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class HomeController
{
    @GetMapping("/")
    public String index(Model model)
    {
        model.addAttribute("operator", "+");
        model.addAttribute("view", "views/calculatorForm");
        return "base-layout";
    }

    @PostMapping("/")
    public String calculate(Model model,
                            @RequestParam String leftOperand,
                            @RequestParam String rightOperand,
                            @RequestParam String operator)
    {
        double firstNumber = 0;
        double secondNumber = 0;

        try
        {
            firstNumber = Double.parseDouble(leftOperand);
        }
        catch (NumberFormatException exception)
        {
        }

        try
        {
            secondNumber = Double.parseDouble(rightOperand);
        }
        catch (NumberFormatException exception)
        {
        }

        Calculator calculator = new Calculator(firstNumber, secondNumber, operator);
        double result = calculator.calculate();

        model.addAttribute("leftOperand", leftOperand);
        model.addAttribute("rightOperand", rightOperand);
        model.addAttribute("operator", operator);
        model.addAttribute("result", result);
        model.addAttribute("view", "views/calculatorForm");

        return "base-layout";
    }
}
