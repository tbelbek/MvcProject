$(function(){
	if ( !Modernizr && !Modernizr.cssanimations ) {
		//animation doesnt show
	} else {
		$('.animated[class*=animated_]').each(function(i){
			var el = $(this);
			var elclass = $(this).attr('class').split('_')[1];
			if ( !el.hasClass('fadeIn') ) {
				el.css('opacity','0');
				timeout(el,elclass,250*i);
			}
		});
	}
});

function timeout(el,elclass,time){
	setTimeout(function(){
		$(el).removeAttr('style').addClass(elclass);
	}, time);
}


/* https://github.com/Idered/cssParentSelector */
//
//(function($) {
//    $.fn.cssParentSelector = function() {
//        var k = 0, i, j,
//            CLASS = 'CPS',
//            stateMap = {
//                hover: 'mouseover mouseout',
//                checked: 'click',
//                focus: 'focus blur',
//                active: 'mousedown mouseup',
//                selected: 'change',
//                changed: 'change'
//            },
//            attachStateMap = {
//                mousedown: 'mouseout'
//            },
//            detachStateMap = {
//                mouseup: 'mouseout'
//            },
//            pseudoMap = {
//                'after': 'appendTo',
//                'before': 'prependTo'
//            },
//            pseudo = {},
//            parsed, matches, selectors, selector,
//            parent, target, child, state, declarations,
//            pseudoParent, pseudoTarget,
//            REGEXP = [
//                /[\w\s\.\-\:\=\[\]\(\)\~\|\'\*\"\^#]*(?=!)/,
//                /[\w\s\.\-\:\=\[\]\(\)\~\|\,\*\^$#>!]+/,
//                /[\w\s\.\-\:\=\[\]\'\,\"#>]*\{{1}/,
//                /[\w\s\.\-\:\=\'\*\|\?\^\+\/\\\(\);#%]+\}{1}/
//            ],
//            REGEX = new RegExp((function(REGEXP) {
//                var ret = '';
//                for (var i = 0; i < REGEXP.length; i++)
//                    ret += REGEXP[i].source;
//                return ret;
//            })(REGEXP), "gi"),
//            parse = function(css) {
//                css = css.replace(/(\/\*([\s\S]*?)\*\/)/gm, '');
//                if ( matches = css.match(REGEX) ) {
//                    parsed = '';
//                    for (i = -1; matches[++i], style = matches[i];) {
//                        selectors = style.split('{')[0].split(',');
//                        declarations = '{' + style.split(/\{|\}/)[1].replace(/^\s+|\s+$[\t\n\r]*/g, '') + '}';
//                        if ( declarations === '{}' ) continue;
//                        declarations = declarations.replace(/;/g, ' !important;');
//                        for (j = -1; selectors[++j], selector = $.trim(selectors[j]);) {
//                            j && (parsed += ',');
//                            if (/!/.test(selector) ) {
//                                parent = $.trim(selector.split('!')[0].split(':')[0]);
//                                target = $.trim(selector.split('!')[1].split('>')[0].split(':')[0]) || []._;
//                                pseudoParent = $.trim(selector.split('>')[0].split('!')[0].split(':')[1]) || []._;
//                                pseudoTarget = target ? ($.trim(selector.split('>')[0].split('!')[1].split(':')[1]) || []._) : []._;
//                                child    = $($.trim(selector.split('>')[1]).split(':')[0]);
//                                state = (selector.split('>')[1].split(/:+/)[1] || '').split(' ')[0] || []._;
//                                child.each(function(i) {
//                                    var subject = $(this)[parent == '*' ? 'parent' : 'closest'](parent);
//                                    pseudoParent && (subject = pseudoMap[pseudoParent] ?
//                                        $('<div></div>')[pseudoMap[pseudoParent]](subject) :
//                                        subject.filter(':' + pseudoParent));
//                                    target && (subject = subject.find(target));
//                                    target && pseudoTarget && (subject = pseudoMap[pseudoTarget] ?
//                                        $('<div></div>')[pseudoMap[pseudoTarget]](subject) :
//                                        subject.filter(':' + pseudoTarget));
//                                    var id = CLASS + k++,
//                                        toggleFn = function(e) {
//                                            e && attachStateMap[e.type] &&
//                                                $(subject).one(attachStateMap[e.type], function() {$(subject).toggleClass(id) });
//                                            e && detachStateMap[e.type] &&
//                                                $(subject).off(detachStateMap[e.type]);
//                                            $(subject).toggleClass(id)
//                                        };
//                                    i && (parsed += ',');
//                                    parsed += '.' + id;
//                                    var $this = $(this);
//                                    if($this.is(':checked') && state === 'checked'){
//                                        $(subject).toggleClass(id);
//                                    }
//                                    ! state ? toggleFn() : $(this).on( stateMap[state] || state , toggleFn );
//                                });
//                            } else {
//                                parsed += selector;
//                            }
//                        }
//                        parsed += declarations;
//                    };
//                    $('<style type="text/css">' + parsed + '</style>').appendTo('head');
//                };
//            };
//        $('link[rel=stylesheet], style').each(function() {
//            $(this).is('link') ?
//                $.ajax({url:this.href,dataType:'text'}).success(function(css) { parse(css); }) : parse($(this).text());
//        });
//    };
//    $().cssParentSelector();
//})(jQuery)