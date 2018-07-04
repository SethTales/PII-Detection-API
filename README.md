This is a REST Api written in C# and using ASP.NET 2.0 that accepts text, determines if the text is likely to contain personally identifying information (PII) and writes the text and PII designation to a database. PII is identified through Regex searching. As of the writing of this README (7/3/18) the API can identify patterns that match social security numbers (###-##-#### or #########) and will flag the submission with a true/false value for 'hasSsn'