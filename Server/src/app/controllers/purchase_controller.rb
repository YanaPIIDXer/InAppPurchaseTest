class PurchaseController < ApplicationController
  def add_money
    render json => { success: true, money: 9999 }
  end
end
