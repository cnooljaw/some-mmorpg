local core = require "spynet.core"

local spynet = {}

function spynet.dispatch_message ()
end

function spynet.timeout (ti, func)
end

function spynet.init_service(start)
end

function spynet.start(start_func)
	core.callback(spynet.dispatch_message)
	spynet.timeout(0, function()
		spynet.init_service(start_func)
	end)
end
