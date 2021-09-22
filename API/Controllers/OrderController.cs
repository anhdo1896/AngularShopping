using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderController : BaseApiController
    {
        private readonly IOrderService _orderSevice;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderSevice, IMapper mapper)
        {
            _mapper = mapper;
            _orderSevice = orderSevice;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var email = HttpContext.User.RetrieveEmailFromPricipal();

            var address = _mapper.Map<AddressDto, Address>(orderDto.ShipToAddress);

            var order = await _orderSevice.CreateOrderAsync(email, orderDto.DeliveryMethodId, orderDto.BasketId, address);

            if (order == null) return BadRequest(new ApiResponse(400, "Problem creating order"));

            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetOrdersForUser()
        {
            var email = HttpContext.User.RetrieveEmailFromPricipal();

            var orders = await _orderSevice.GetOdersForUserAsync(email);

            if (orders == null) return BadRequest(new ApiResponse(400, "Problem get order"));

               return Ok(_mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDto>>(orders));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrdersByIdForUser(int id)
        {
            var email = HttpContext.User.RetrieveEmailFromPricipal();

            var order = await _orderSevice.GetOrderByIdAsync(id, email);

            if (order == null) return BadRequest(new ApiResponse(400, "Problem get order by Id"));

            return Ok(_mapper.Map<Order, OrderToReturnDto>(order));
        }

        [HttpGet("deliveryMethods")]
        public async Task<ActionResult<IReadOnlyList<Order>>> GetDeliveryMethod()
        {

            var deliveryMethods = await _orderSevice.GetDeliveryMethodsAsync();

            if (deliveryMethods == null) return BadRequest(new ApiResponse(400, "Problem get delivery methods"));

            return Ok(deliveryMethods);
        }
    }
}