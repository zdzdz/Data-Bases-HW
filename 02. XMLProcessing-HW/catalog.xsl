<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <style>
        th, td {
        padding: 5px;
        text-align: center;
        }
      </style>
      <body>
        <h1>Albums</h1>
        <table bgcolor="#E0E0E0" cellspacing="1">
          <tr bgcolor="#EEEEEE">
            <th>Name</th>
            <th>Artist</th>
            <th>Year</th>
            <th>Producer</th>
            <th>Price</th>
            <th>Songs</th>
          </tr>
          <xsl:for-each select="/catalog/album">
            <tr bgcolor="white">
              <td>
                <xsl:value-of select="name" />
              </td>
              <td>
                <xsl:value-of select="artist" />
              </td>
              <td>
                <xsl:value-of select="year" />
              </td>
              <td>
                <xsl:value-of select="producer" />
              </td>
              <td>
                <xsl:value-of select="price" />
              </td>
              <td>
                <table cellspacing="1">
                  <tr bgcolor="#EEEEEE">
                    <th>Title</th>
                    <th>Duration</th>
                  </tr>
                  <xsl:for-each select="song">
                    <tr>
                      <td>
                        <xsl:value-of select="title" />
                      </td>
                      <td>
                        <xsl:value-of select="duration" />
                      </td>
                    </tr>
                  </xsl:for-each>
                </table>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>