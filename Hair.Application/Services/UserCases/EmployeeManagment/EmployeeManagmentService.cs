﻿using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Interfaces.UserCases;

namespace Hair.Application.Services.UserCases.EmployeeManagment
{
    /// <summary>
    /// Classe para gerenciamento do funcionário, como contratar, demitir e entre outros.
    /// </summary>
    public class EmployeeManagmentService : IEmployeeManagment
    {
        private readonly IUpdateEmployee _updateEmployee;
        private readonly ICreateEmployee _createEmployee;
        private readonly IDeleteEmployee _deleteEmployee;
        private readonly IViewEmployeeData _viewEmployeeData;

        public EmployeeManagmentService(IUpdateEmployee update, ICreateEmployee create, IDeleteEmployee fire, IViewEmployeeData viewEmployeeData)
        {
            _updateEmployee = update;
            _createEmployee = create;
            _deleteEmployee = fire;
            _viewEmployeeData = viewEmployeeData;
        }

        public BaseDto Update(UpdateEmployeeDto dto) => _updateEmployee.Update(dto);
        public BaseDto Hire(CreateEmployeeDto dto) => _createEmployee.Create(dto);
        public BaseDto Fire(DeleteEmployeeDto dto) => _deleteEmployee.Delete(dto);
        public BaseDto ViewEmplooData(string userEmail, string userPassword) => _viewEmployeeData.GetEmployeeData(userEmail, userPassword);
    }
}