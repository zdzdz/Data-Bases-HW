<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>Students</title>
        <style>
          body
          {
          display: flex;
          flex-direction: row;
          flex-wrap: wrap;
          justify-content: center;
          align-items: center;
          background-color: limegreen;
          }
          h2
          {
          background:#B00000;
          color:white;
          padding:10px;
          width: 50%;
          border-radius:10px;
          text-align: center;
          }
          .allStudents{
          width:50%;
          margin: 50px;
          padding: 0px;
          height: 500px;
          overflow-y: scroll;
          }
          .student-container
          {
          width:90%;
          margin:10px;
          background:dodgerblue;
          color:white;
          font-size:20px;
          padding:10px;
          border-radius:10px;
          }
          .exam-title
          {
          margin-left:20px;
          }
          .exam-container
          {
          margin-left:40px;
          }
        </style>
      </head>
      <body>
        <h2>Students</h2>
        <div class="allStudents">
        <xsl:for-each select="students/student">
          <div class="student-container">
            Name: <xsl:value-of select="name"/> <br />
            Gender: <xsl:value-of select="gender"/> <br />
            Birth date: <xsl:value-of select="birthDate"/> <br />
            Phone: <xsl:value-of select="phone"/> <br />
            Email: <xsl:value-of select="email"/> <br />
            Course: <xsl:value-of select="course"/> <br />
            Specialty: <xsl:value-of select="specialty"/>
            <div>
              Faculty Number: <xsl:value-of select="faculty-number"/>
            </div>
            <div class="exam-title">Taken exams:</div>
            <xsl:for-each select="exams/exam">
              <div class="exam-container">
                <xsl:value-of select="position()"/>. <xsl:value-of select="name"/> - Score: <xsl:value-of select="score"/> (Tutor: <xsl:value-of select="tutor"/>)
              </div>
            </xsl:for-each>
          </div>
        </xsl:for-each>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>