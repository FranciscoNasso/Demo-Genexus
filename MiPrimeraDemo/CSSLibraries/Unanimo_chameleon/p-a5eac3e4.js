function e(e){const t=["if","then","else","do","while","until","for","loop","import","with","is","as","where","when","by","data","constant","integer","real","text","name","boolean","symbol","infix","prefix","postfix","block","tree"],a=["in","mod","rem","and","or","xor","not","abs","sign","floor","ceil","sqrt","sin","cos","tan","asin","acos","atan","exp","expm1","log","log2","log10","log1p","pi","at","text_length","text_range","text_find","text_replace","contains","page","slide","basic_slide","title_slide","title","subtitle","fade_in","fade_out","fade_at","clear_color","color","line_color","line_width","texture_wrap","texture_transform","texture","scale_?x","scale_?y","scale_?z?","translate_?x","translate_?y","translate_?z?","rotate_?x","rotate_?y","rotate_?z?","rectangle","circle","ellipse","sphere","path","line_to","move_to","quad_to","curve_to","theme","background","contents","locally","time","mouse_?x","mouse_?y","mouse_buttons"],n=["ObjectLoader","Animate","MovieCredits","Slides","Filters","Shading","Materials","LensFlare","Mapping","VLCAudioVideo","StereoDecoder","PointCloud","NetworkAccess","RemoteControl","RegExp","ChromaKey","Snowfall","NodeJS","Speech","Charts"],o={$pattern:/[a-zA-Z][a-zA-Z0-9_?]*/,keyword:t,literal:["true","false","nil"],built_in:a.concat(n)},i={className:"string",begin:'"',end:'"',illegal:"\\n"},s={className:"string",begin:"'",end:"'",illegal:"\\n"},l={className:"string",begin:"<<",end:">>"},r={className:"number",begin:"[0-9]+#[0-9A-Z_]+(\\.[0-9-A-Z_]+)?#?([Ee][+-]?[0-9]+)?"},c={beginKeywords:"import",end:"$",keywords:o,contains:[i]},d={className:"function",begin:/[a-z][^\n]*->/,returnBegin:!0,end:/->/,contains:[e.inherit(e.TITLE_MODE,{starts:{endsWithParent:!0,keywords:o}})]};return{name:"XL",aliases:["tao"],keywords:o,contains:[e.C_LINE_COMMENT_MODE,e.C_BLOCK_COMMENT_MODE,i,s,l,d,c,r,e.NUMBER_MODE]}}export{e as default};
//# sourceMappingURL=p-a5eac3e4.js.map