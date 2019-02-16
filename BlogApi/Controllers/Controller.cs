using BlogApi.Model;
using BlogApi.Model.Logging;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogApi.Controllers
{
    public class Controller: ControllerBase
    {
        protected BlogContext db;
        protected ILog logger;

        public Controller(BlogContext context, ILog logger)
        {
            db = context;
            this.logger = logger;
        }

        protected ActionResult<T> UseDatabaseWithValidModel<T>(Func<ActionResult<T>> action)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (db)
                    {
                        return action.Invoke();
                    }
                }
                else
                {
                    return ValidationProblem(ModelState);
                }
            }
            catch (Exception e)
            {
                logger.LogException(GetType(), e.Message, e);
                return new StatusCodeResult(500);
            }

        }

        protected ActionResult UseDatabaseWithValidModel(Func< ActionResult> action)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (db)
                    {
                        return action.Invoke();
                    }
                }
                else
                {
                    return ValidationProblem(ModelState);
                }
            }
            catch (Exception e)
            {
                logger.LogException(GetType(), e.Message, e);
                return new StatusCodeResult(500);
            }

        }
    }
}
