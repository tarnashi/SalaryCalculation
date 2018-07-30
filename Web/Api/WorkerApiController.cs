using Core.Abstract;
using System.Web.Mvc;
using System;
using Core.ViewModels;
using Web.Attributes;

namespace Web.Api
{
    [Authorize]
    [CustomAuthorize("superuser")]
    public class WorkerApiController : BaseApiController
    {
        private readonly IStaffService _staff;
        private readonly IValidationService _validation;

        public WorkerApiController(IStaffService staffService, IValidationService validationService)
        {
            _staff = staffService;
            _validation = validationService;
        }

        [HttpPost]
        public JsonResult AddWorker(NewWorkerModel workerModel)
        {
            if (ModelState.IsValid && _validation.ValidateNewWorkerModel(workerModel))
            {
                _staff.AddWorker(workerModel);
                return SuccessJsonResponse(message: "Сотрудник добавлен");
            }
            else
            {
                return FailJsonResponse($"Что-то пошло не так :({Environment.NewLine}Проверьте данные и попробуйте ещё раз");
            }
        }

    }
}