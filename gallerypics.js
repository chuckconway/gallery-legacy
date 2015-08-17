/* -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
	Written by Bugimus 
	Copyright © 1998-2001 Bugimus, all rights reserved.
	You may use this code for your own *personal* use provided you leave this comment block intact.  
	A link back to Bugimus' page would be much appreciated.  
	http://bugimus.com/
=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- */

/*-------------------------------------------------------------------------------------------------------------
	Modified by Charles Conway
	www.cconway.com
	January 2003
	Added Description, Title and Date
--------------------------------------------------------------------------------------------------------------*/

function showPic( imgName, imgCaption, descript, title, date) 
	{
	w = window.open('','Demo','toolbar=no,location=no,directories=no,status=no,scrollbars=no,resizable=no,copyhistory=no');
	w.document.write( "<html>" );
	w.document.write( "<head>" );
	w.document.write( "<title>"+imgCaption+" - cconway.com</title>" );
	w.document.write( "<style type='text/css' media='all'>@import 'gallery.css';</style>" );
	w.document.write( "<script language='javascript'>" );
	w.document.write( "function autosize() {\n" );
	w.document.write( "self.resizeTo(document.images[0].width+45,document.images[0].height+135)\n" );
	w.document.write( "self.focus()\n" );
	w.document.write( "}\n");
	w.document.write( "</script>\n");
	w.document.write( "</head>" );
	w.document.write( "<body onload='javascript:autosize()'>" );
	w.document.write( "<div class='padding'>" );
	w.document.write( "<div class='center'><b>title:</b> "+title+"	&nbsp;&nbsp;<b>date taken:</b> "+date+"</div>" );
	w.document.write( "<div class='frame'><a href='javascript:top.window.close()'><img src='"+imgName+"' alt='"+imgCaption+"'></a></div>" );
	w.document.write( "</div><br /><div class='center'><b>description</b><br />"+descript+"</div>" );
	w.document.write( "</body></html>" );
	w.document.close();
	}

