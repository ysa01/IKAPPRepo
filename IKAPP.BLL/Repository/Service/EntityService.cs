using IKAPP.BLL.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKAPP.BLL.Repository.Service
{
    public class EntityService
    {
        public EntityService()
        {
            _userService = new UserRepository();
            _categoryService = new CategoryRepository();
            _employeeService = new EmployeeRepository();
            _productService = new ProductRepository();
            _orderService = new OrderRepository();
            _customerService = new CustomerRepository();
        }
        
        private UserRepository _userService;
        public UserRepository userService
        {
            get { return _userService; }
            set { _userService = value; }
        }

        private CategoryRepository _categoryService;

        public CategoryRepository categoryService
        {
            get { return _categoryService; }
            set { _categoryService = value; }
        }

        private EmployeeRepository _employeeService;

        public EmployeeRepository employeeService
        {
            get { return _employeeService; }
            set { _employeeService = value; }
        }
        private ProductRepository _productService;

        public ProductRepository productService
        {
            get { return _productService; }
            set { _productService = value; }
        }

        private OrderRepository _orderService;

        public OrderRepository orderService
        {
            get { return _orderService; }
            set { _orderService = value; }
        }

        private CustomerRepository _customerService;

        public CustomerRepository customerService
        {
            get { return _customerService; }
            set { _customerService = value; }
        }





    }
}
