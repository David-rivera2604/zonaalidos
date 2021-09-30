using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architect.API.Core.Business.General
{
    public static class CustomFields
    {

        public static string Render(int entityType, int companyId)
        {
            List<Architect.API.Core.Contracts.General.CustomFields> fields = Architect.API.Core.DataAccess.General.CustomFields.RetrieveByEntityType(entityType, companyId);
            if (fields.IsEmpty())
            {

                return string.Empty;
            }

            StringBuilder code = new StringBuilder();
            foreach (Architect.API.Core.Contracts.General.CustomFields customField in fields)
            {
                switch (customField.DataType)
                {
                    default: // 1 -String
                        code.Append(TextControl(customField));
                        break;
                }
            }

            return code.ToString();
        }

        private static string TextControl(Architect.API.Core.Contracts.General.CustomFields customField)
        {
            StringBuilder code = new StringBuilder();
            code.Append("<div class='col-sm-4 col-md-4'>");
            code.Append("<div class='form-group'>");
            code.AppendFormat("<label class='control-label' for='{0}'>{1}", customField.Name, customField.Caption);
            if (customField.IsRequired)
            {
                code.Append("<span class='required-mark'>*</span>");
            }
            code.Append("</label>");
            code.AppendFormat("<input id='{0}' name='{0}' type='text' class='form-control' size='{1}' maxlength='{1}' data-custom='true'>", customField.Name, customField.Precision);
            code.Append("</div>");
            code.Append("</div>");

            return code.ToString();
        }

    }
}
