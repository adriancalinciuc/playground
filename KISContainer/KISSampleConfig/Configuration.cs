using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KISSampleConfig
{
    public class Configuration : KISContainer.KISConfiguration
    {

        public override KISContainer.KISConfiguration.ConfigurationModelType ModelType
        {
            get
            {
                return ConfigurationModelType.Convention;
            }
            set
            {
                throw new NotImplementedException();
            }
        }



        protected override KISContainer.KISComponent ConfigurationSource
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override KISContainer.KISComponent ConfigurationModel
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }



        protected override void LoadConfigurationFromSource()
        {
            throw new NotImplementedException();
        }

        private class Model : KISContainer.KISComponent
        {


        }

    }
}
