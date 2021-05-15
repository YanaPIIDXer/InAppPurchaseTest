class LoginController < ApplicationController
    def index
        response = {result: false, gold: 0, sp_mode: false}
        
        name = params["name"]
        user = User.find_by(name: name)
        if user == nil then
            user = User.new(name: name)
            if !user.save() then
                render :json => response
                return
            end
        end

        session[:id] = user.id

        response[:result] = true
        response[:gold] = user.gold
        response[:sp_mode] = user.sp_mode

        render :json => response
    end
end
