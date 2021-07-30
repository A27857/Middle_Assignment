using System.Linq;
using System.IO;
using System.Net;
using System;
using Microsoft.AspNetCore.Mvc;
using Middle_Assignments.Models.Users;
using System.Collections.Generic;

namespace Middle_Assignments
{

    public class BookBorrowingRequestController : ControllerBase
    {
        private IBookBorrowingRequestService _bookBorrowRequest;
        public BookBorrowingRequestController(IBookBorrowingRequestService bookBorrowRequest)
        {
            _bookBorrowRequest = bookBorrowRequest;
        }

        [HttpPost("request")]
        public IActionResult CreateRequest(CreateBookBorrowRequestModel model)
        {
            try
            {
                var isCreateSuccess = _bookBorrowRequest.CreateRequest(model);
                if (!isCreateSuccess)
                    return BadRequest();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("requests")]
        public IActionResult GetAllRequest()
        {
            try
            {
                var requests = _bookBorrowRequest.GetAllRequest();
                if (requests == null)
                {
                    return BadRequest();
                }
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("request/{id}")]
        public IActionResult GetRequestById(int id)
        {
            try
            {
                var request = _bookBorrowRequest.GetRequestById(id);
                if (request == null)
                {
                    return BadRequest();
                }
                return Ok(request);
            }
            catch (System.Exception ex)
            {
                // TODO
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("request")]
        public IActionResult UpdateRequest(UpdateBookBorrowRequestModel model)
        {
            try
            {
                var isUpdateSuccess = _bookBorrowRequest.UpdateRequest(model);
                if (!isUpdateSuccess)
                    return BadRequest();
                return Ok();
            }
            catch (System.Exception ex)
            {
                // TODO
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("request/{id}")]
        public IActionResult DeleteRequestById(int id)
        {
            try
            {
                var isDeleteSuccess = _bookBorrowRequest.DeleteRequestById(id);
                if (!isDeleteSuccess)
                    return BadRequest();
                return Ok();
            }
            catch (System.Exception ex)
            {
                // TODO
                return BadRequest(ex.Message);
            }
        }
    }
}