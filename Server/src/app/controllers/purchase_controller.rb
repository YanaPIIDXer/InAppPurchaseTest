class PurchaseController < ApplicationController
  def add_money
    render json => { "success": true }
  end
end
