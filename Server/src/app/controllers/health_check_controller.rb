class HealthCheckController < ApplicationController
    def index
        render :json => {message: "ジャブジャブ課金"}
    end
end
