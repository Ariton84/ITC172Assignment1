using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Tip
/// </summary>
public class Tip
{
    //fields: class level variables that describe the class
    public double MealAmount { set; get; }
    public double TipPercent { set; get; }

    private const double TAXPERCENT = .09;

    public Tip()
    {
        MealAmount = 0;
        TipPercent = 0;
    }
    public Tip(double meal, Double percent)
    {
        MealAmount = meal;
        TipPercent = percent;
    }
    public double CalculateTax()
    {
        return MealAmount * TAXPERCENT;
    }
    public double CalculateTip()
    {
        return MealAmount * TipPercent;
    }
    public double CalculateTotal()
    {
        return MealAmount + CalculateTax() + CalculateTip();
    }
}