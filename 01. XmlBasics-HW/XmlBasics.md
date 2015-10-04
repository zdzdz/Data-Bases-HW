### XML Basics ###

1. What does the XML language represents? What does it used for?
	* XML means EXtensible Markup Language and is pretty much like HTML.  The data itself is self-described and self-defined. It is well formed and thus XML parser could easily read and understand it. Elements are the building blocks of the XML. They are enclosed by open and close tag.
	* It is designed to focuses on documents but it's widely used to store and transport data over the internet.
	
1. What do namespaces represent in an XML document? What are they used for?
	* XML Namespaces enable the same document to contain XML elements and attributes taken from different vocabularies, without any naming collisions occurring.
    * Although XML Namespaces are not part of the XML specification itself, virtually all XML software also supports XML Namespaces.

1. Explore [http://en.wikipedia.org/wiki/Uniform_Resource_Identifier](http://en.wikipedia.org/wiki/Uniform_Resource_Identifier) to learn more about URI, URN and URL definitions. 

	* scheme

                		hierarchical part
        		┌───────────────────┴─────────────────────┐
                    authority               path
        		┌───────────────┴───────────────┐┌───┴────┐
  				abc://username:password@example.com:123/path/data?key=value#fragid1
  				└┬┘   └───────┬───────┘ └────┬────┘ └┬┘           └───┬───┘ └──┬──┘
				scheme  user information     host     port            query   fragment

  				urn:example:mammal:monotreme:echidna
  				└┬┘ └──────────────┬───────────────┘
				scheme              path
