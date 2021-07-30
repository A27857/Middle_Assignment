// using System.Security.Claims;
// using Microsoft.AspNetCore.Mvc.Filters;

// namespace Middle_Assignments
// {
//     public class Permission : ActionFilterAttribute
//     {
//         public bool Type {set;get;}
//         public override void OnActionExecuting(ActionExecutedContext context)
//         {
//             var claim = new ClaimsIdentity(new Claim[] {
//                 new Claim (ClaimTypes.Name, ClaimTypes.UserRole)
//             });
//             if (Type) 
//             {
//                 base.OnActionExecuting(context);
//                 return;
//             }
//             if(ClaimTypes.UseRole == 1)
//             {
//                 base.OnActionExecuting(context);
//             }
//             else
//             {
//                 context.Result = new RedirectResult("url");
//                 // return false => 
//             }

//         }
//     }
// }