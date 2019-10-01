using System;
using System.Linq;

namespace LunTi.Models
{
    public class Lab1Data
   {
       public string BookName { get; set; }
       public string Author { get; set; }
       public int Pages { get; set; }
       public string Publisher { get; set; }
   public Guid Id { get; set; } = Guid.Empty;
    public BaseModelValidationResult Validate()
       {
           var validationResult = new BaseModelValidationResult();

           if (string.IsNullOrWhiteSpace(BookName)) validationResult.Append($"BookName cannot be empty");
           if (string.IsNullOrWhiteSpace(Author)) validationResult.Append($"Author cannot be empty");
           if (!(0 < Pages && Pages < 200)) validationResult.Append($"Pages {Pages} is out of range (0..200)");

           if (!string.IsNullOrEmpty(BookName) && !char.IsUpper(BookName.FirstOrDefault())) validationResult.Append($"BookName {BookName} should start from capital letter");
           if (!string.IsNullOrEmpty(Author) && !char.IsUpper(Author.FirstOrDefault())) validationResult.Append($"Author {Author} should start from capital letter");
            if (!string.IsNullOrEmpty(Publisher) && !char.IsUpper(Publisher.FirstOrDefault())) validationResult.Append($"Publisher {Publisher} should start from capital letter");


           return validationResult;
       }

       public override string ToString()
       {
           return $"'{BookName}' {Author} from {Publisher}-{Pages} pages ";
       }
   }}

