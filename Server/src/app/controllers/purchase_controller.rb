class PurchaseController < ApplicationController
  before_action :check_session
  skip_before_action :check_session, only: [:session_fail]
  
  def add_gold
    store = params["Store"]
    verify = false
    if store == "fake" then
      verify = true
    end

    user = User.find_by(id: session[:id])
    gold = user.gold
    if verify then
      user.gold += 100
      gold = user.gold
      user.save()
    end

    render :json => { success: verify, gold: gold }
  end

  def session_fail
    render :json => { success: false }
  end

  def check_session
    if session[:id] == nil
      redirect_to action: :session_fail
    end
  end
end
