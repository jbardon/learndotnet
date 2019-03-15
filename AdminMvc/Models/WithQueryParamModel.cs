using System;

namespace AdminMvc.Models
{
    public class WithQueryParamModel
    {
        /**
         * Accessible in the Razor view using this model
         */
        public String QueryParam;

        public WithQueryParamModel(string queryParam)
        {
            QueryParam = queryParam;
        }
    }
}