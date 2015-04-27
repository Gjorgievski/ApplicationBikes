using ApplicationBike.BusinessLayer.Contracts;
using ApplicationBike.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using ApplicationBike.DomainModel;

namespace ApplicationBike.BusinessLayer.Handlers
{
    internal class BikeSearchCommandHandler : CommandHandlerBase<BikeSearchCommand, BikeSearchResult>
    {
        protected override BikeSearchResult ExecuteCommand(BikeSearchCommand command)
        {
            using (RegistarDbContext context = new RegistarDbContext())
            {


                var query = from b in context.Bikes
                            select b;

                if (!string.IsNullOrEmpty(command.RegNumber))
                {
                    query = query.Where(x => x.RegNumber.ToLower() == command.RegNumber.ToLower());
                }
                if (!string.IsNullOrEmpty(command.Colour))
                {
                    query = query.Where(x => x.Colour.ToLower() == command.Colour.ToLower());
                }
                if (!string.IsNullOrEmpty(command.Producer))
                {
                    query = query.Where(x => x.Producer.ToLower() == command.Producer.ToLower());
                }

                query = query
                        .OrderBy(x => x.BikeId);
                       
                int tmp = query.Count();

                query = query
                        .Skip(command.PageIndex * command.PageSize)
                        .Take(command.PageSize);
                

                BikeSearchResult result = new BikeSearchResult();
                result.Result = query.ToList();
                int totalPages= (int) Math.Ceiling(tmp / (double)command.PageSize);
                result.HasNext=(command.PageIndex+1 < totalPages);
                result.HasPrevious=(command.PageIndex > 0);
                return result;
            }

        }
    }
}
