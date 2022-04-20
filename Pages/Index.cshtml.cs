using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EqSolve;

namespace EqSolveWeb.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    [BindProperty]
    public string Equation { get; set; } = string.Empty;

    [BindProperty]
    public string X { get; set; } = "0";

    [BindProperty]
    public string Y { get; set; } = "0";

    [BindProperty]
    public string Z { get; set; } = "0";

    [BindProperty]
    public string Answer { get; set; } = string.Empty;

    public void OnGet()
    {

    }

    public void OnPost()
    {
        try
        {
            double answer = Solver.Solve(Parser.ParseToTerms(Equation, X, Y, Z));
            Answer = answer.ToString();
        }
        catch (Exception)
        {
            Answer = "Invalid equation or xyz values.";
        }
    }
}
