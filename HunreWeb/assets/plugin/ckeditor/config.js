/**
 * @license Copyright (c) 2003-2022, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/assets/plugin/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/assets/plugin/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/assets/plugin/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/assets/plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/assets/Image';
    config.filebrowserFlashUploadUrl = '/assets/plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '/assets/plugin/ckfinder/');
};
