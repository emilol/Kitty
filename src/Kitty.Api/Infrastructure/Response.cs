using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Kitty.Core.Infrastructure;
using Kitty.Core.Extensions;

namespace Kitty.Api.Infrastructure
{
    public static class Response
    {
        public static NegotiatedContentResult<ResponseObject> FromResult<T>(Result<T> result)
        {
            var responseObject = new ResponseObject()
                                 {
                                     ItemType = typeof (T).GetCollectionItemType(),
                                     Items = result.WasSuccessful ? (object) result.Value : null,
                                     Errors = result.WasFailure ? result.Errors : null
                                 };

            return new NegotiatedContentResult<ResponseObject>(
                result.WasSuccessful
                    ? HttpStatusCode.OK
                    : HttpStatusCode.BadRequest, responseObject);
        }

        public class ResponseObject
        {
            public string ItemType { get; set; }
            public object Items { get; set; }
            public IEnumerable<string> Errors { get; set; }
        }
    }
}